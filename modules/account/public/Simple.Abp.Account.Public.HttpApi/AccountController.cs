using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Identity;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Account
{
    [RemoteService(true, Name = AccountProPublicRemoteServiceConsts.RemoteServiceName)]
	[Route("api/account")]
	[Area("account")]
	public class AccountController : AbpController, IAccountAppService, IRemoteService, IApplicationService
	{
		protected IAccountAppService AccountAppService { get; }

		public AccountController(IAccountAppService accountAppService)
		{
			this.AccountAppService = accountAppService;
		}

		[Route("register")]
		[HttpPost]
		public virtual Task<IdentityUserDto> RegisterAsync(RegisterDto input)
		{
			return this.AccountAppService.RegisterAsync(input);
		}

		[Route("send-password-reset-code")]
		[HttpPost]
		public virtual Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
		{
			return this.AccountAppService.SendPasswordResetCodeAsync(input);
		}

		[HttpPost]
		[Route("reset-password")]
		public virtual Task ResetPasswordAsync(ResetPasswordDto input)
		{
			return this.AccountAppService.ResetPasswordAsync(input);
		}

		[Route("send-phone-number-confirmation-token")]
		[HttpPost]
		public Task SendPhoneNumberConfirmationTokenAsync()
		{
			return this.AccountAppService.SendPhoneNumberConfirmationTokenAsync();
		}

		[HttpPost]
		[Route("confirm-phone-number")]
		public Task ConfirmPhoneNumberAsync(ConfirmPhoneNumberInput input)
		{
			return this.AccountAppService.ConfirmPhoneNumberAsync(input);
		}

		[Route("confirm-email")]
		[HttpPost]
		public Task ConfirmEmailAsync(ConfirmEmailInput input)
		{
			return this.AccountAppService.ConfirmEmailAsync(input);
		}
	}
}
