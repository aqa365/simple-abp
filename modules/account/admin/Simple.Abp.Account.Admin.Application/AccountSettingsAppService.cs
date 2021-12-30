using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Simple.Abp.Account
{
	[Authorize(AccountPermissions.SettingManagement)]
	public class AccountSettingsAppService : ApplicationService, IRemoteService, IApplicationService, IAccountSettingsAppService
	{
		protected ISettingManager SettingManager { get; }

		public AccountSettingsAppService(ISettingManager settingManager)
		{
			this.SettingManager = settingManager;
		}

		public virtual async Task<AccountSettingsDto> GetAsync()
		{
			var accountSettingsDto = new AccountSettingsDto();
			bool isSelfRegistrationEnabled = await SettingProvider.GetAsync<bool>("Abp.Account.IsSelfRegistrationEnabled", false);
			accountSettingsDto.IsSelfRegistrationEnabled = isSelfRegistrationEnabled;
			bool enableLocalLogin = await SettingProvider.GetAsync<bool>("Abp.Account.EnableLocalLogin", false);
			accountSettingsDto.EnableLocalLogin = enableLocalLogin;
			bool isRememberBrowserEnabled = await SettingProvider.GetAsync<bool>("Abp.Account.TwoFactorLogin.IsRememberBrowserEnabled", false);
			accountSettingsDto.IsRememberBrowserEnabled = isRememberBrowserEnabled;
			return accountSettingsDto;
		}

		public virtual async Task UpdateAsync(AccountSettingsDto input)
		{
			if (input != null)
			{
				await SettingManager.SetForCurrentTenantAsync("Abp.Account.IsSelfRegistrationEnabled", input.IsSelfRegistrationEnabled.ToString());
				await SettingManager.SetForCurrentTenantAsync("Abp.Account.EnableLocalLogin", input.EnableLocalLogin.ToString());
				await SettingManager.SetForCurrentTenantAsync("Abp.Account.TwoFactorLogin.IsRememberBrowserEnabled", input.IsRememberBrowserEnabled.ToString());
			}
		}
	}
}
