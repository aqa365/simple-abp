﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Simple.Abp.Account.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Simple.Abp.Account.Public.Web.Pages.Account
{
    public class LoginModel : AccountPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public string ReturnUrlHash { get; set; }

        [BindProperty]
        public LoginInputModel LoginInput { get; set; }

        public bool EnableLocalLogin { get; set; }

        //TODO: Why there is an ExternalProviders if only the VisibleExternalProviders is used.
        public IEnumerable<ExternalProviderModel> ExternalProviders { get; set; }
        public IEnumerable<ExternalProviderModel> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;

        //Optional IdentityServer services
        //public IIdentityServerInteractionService Interaction { get; set; }
        //public IClientStore ClientStore { get; set; }
        //public IEventService IdentityServerEvents { get; set; }

        protected IAuthenticationSchemeProvider SchemeProvider { get; }
        protected AbpAccountOptions AccountOptions { get; }

        public bool ShowCancelButton { get; set; }

        public LoginModel(
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions)
        {
            SchemeProvider = schemeProvider;
            AccountOptions = accountOptions.Value;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            LoginInput = new LoginInputModel();

            ExternalProviders = await GetExternalProviders();

            EnableLocalLogin = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin);

            if (IsExternalLoginOnly)
            {
                //return await ExternalLogin(vm.ExternalLoginScheme, returnUrl);
                throw new NotImplementedException();
            }

            return Page();
        }

        public virtual async Task<IActionResult> OnPostAsync(string action)
        {
            await CheckLocalLoginAsync();

            ValidateModel();

            ExternalProviders = await GetExternalProviders();

            EnableLocalLogin = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin);

            await ReplaceEmailToUsernameOfInputIfNeeds();

            var result = await SignInManager.PasswordSignInAsync(
                LoginInput.UserNameOrEmailAddress,
                LoginInput.Password,
                LoginInput.RememberMe,
                true
            );

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.Identity,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = LoginInput.UserNameOrEmailAddress
            });

            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./SendSecurityCode", new
                {
                    returnUrl = ReturnUrl,
                    returnUrlHash = ReturnUrlHash,
                    rememberMe = LoginInput.RememberMe
                });
            }

            if (result.IsLockedOut)
            {
                Alerts.Warning(L["UserLockedOutMessage"]);
                return Page();
            }

            if (result.IsNotAllowed)
            {
                Alerts.Warning(L["LoginIsNotAllowed"]);
                return Page();
            }

            if (!result.Succeeded)
            {
                Alerts.Danger(L["InvalidUserNameOrPassword"]);
                return Page();
            }

            //TODO: Find a way of getting user's id from the logged in user and do not query it again like that!
            var user = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress) ??
                       await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);

            Debug.Assert(user != null, nameof(user) + " != null");

            return RedirectSafely(ReturnUrl, ReturnUrlHash);
        }

        protected virtual async Task<List<ExternalProviderModel>> GetExternalProviders()
        {
            var schemes = await SchemeProvider.GetAllSchemesAsync();

            return schemes
                .Where(x => x.DisplayName != null || x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                .Select(x => new ExternalProviderModel
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                })
                .ToList();
        }

        public virtual async Task<IActionResult> OnPostExternalLogin(string provider)
        {
            var redirectUrl = Url.Page("./Login", pageHandler: "ExternalLoginCallback", values: new { ReturnUrl, ReturnUrlHash });
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            properties.Items["scheme"] = provider;

            return await Task.FromResult(Challenge(properties, provider));
        }

        public virtual async Task<IActionResult> OnGetExternalLoginCallbackAsync(string returnUrl = "", string returnUrlHash = "", string remoteError = null)
        {
            //TODO: Did not implemented Identity Server 4 sample for this method (see ExternalLoginCallback in Quickstart of IDS4 sample)
            /* Also did not implement these:
             * - Logout(string logoutId)
             */

            if (remoteError != null)
            {
                Logger.LogWarning($"External login callback error: {remoteError}");
                return RedirectToPage("./Login");
            }

            var loginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                Logger.LogWarning("External login info is not available");
                return RedirectToPage("./Login");
            }

            var result = await SignInManager.ExternalLoginSignInAsync(
                loginInfo.LoginProvider,
                loginInfo.ProviderKey,
                isPersistent: false,
                bypassTwoFactor: true
            );

            if (!result.Succeeded)
            {
                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
                {
                    Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                    Action = "Login" + result
                });
            }

            if (result.IsLockedOut)
            {
                throw new UserFriendlyException("Cannot proceed because user is locked out!");
            }

            if (result.Succeeded)
            {
                return RedirectSafely(returnUrl, returnUrlHash);
            }

            //TODO: Handle other cases for result!

            // Get the information about the user from the external login provider
            var externalLoginInfo = await SignInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                throw new ApplicationException("Error loading external login information during confirmation.");
            }

            if (!IsEmailRetrievedFromExternalLogin(externalLoginInfo))
            {
                return RedirectToPage("./Register", new
                {
                    IsExternalLogin = true,
                    ExternalLoginAuthSchema = externalLoginInfo.LoginProvider,
                    ReturnUrl = returnUrl
                });
            }

            var user = await CreateExternalUserAsync(externalLoginInfo);

            await SignInManager.SignInAsync(user, false);

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
            {
                Identity = IdentitySecurityLogIdentityConsts.IdentityExternal,
                Action = result.ToIdentitySecurityLogAction(),
                UserName = user.Name
            });

            return RedirectSafely(returnUrl, returnUrlHash);
        }

        private static bool IsEmailRetrievedFromExternalLogin(ExternalLoginInfo externalLoginInfo)
        {
            return externalLoginInfo.Principal.FindFirstValue(AbpClaimTypes.Email) != null;
        }

        protected virtual async Task<IdentityUser> CreateExternalUserAsync(ExternalLoginInfo info)
        {
            var emailAddress = info.Principal.FindFirstValue(AbpClaimTypes.Email);

            var user = new IdentityUser(GuidGenerator.Create(), emailAddress, emailAddress, CurrentTenant.Id);

            CheckIdentityErrors(await UserManager.CreateAsync(user));
            CheckIdentityErrors(await UserManager.SetEmailAsync(user, emailAddress));
            CheckIdentityErrors(await UserManager.AddLoginAsync(user, info));
            CheckIdentityErrors(await UserManager.AddDefaultRolesAsync(user));

            return user;
        }

        protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds()
        {
            if (!ValidationHelper.IsValidEmailAddress(LoginInput.UserNameOrEmailAddress))
            {
                return;
            }

            var userByUsername = await UserManager.FindByNameAsync(LoginInput.UserNameOrEmailAddress);
            if (userByUsername != null)
            {
                return;
            }

            var userByEmail = await UserManager.FindByEmailAsync(LoginInput.UserNameOrEmailAddress);
            if (userByEmail == null)
            {
                return;
            }

            LoginInput.UserNameOrEmailAddress = userByEmail.UserName;
        }

        protected virtual async Task CheckLocalLoginAsync()
        {
            if (!await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin))
            {
                throw new UserFriendlyException(L["LocalLoginDisabledMessage"]);
            }
        }

        public class LoginInputModel
        {
            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
            public string UserNameOrEmailAddress { get; set; }

            [Required]
            [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPasswordLength))]
            [DataType(DataType.Password)]
            [DisableAuditing]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public class ExternalProviderModel
        {
            public string DisplayName { get; set; }
            public string AuthenticationScheme { get; set; }
        }
    }
}
