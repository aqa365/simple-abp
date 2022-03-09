using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Account
{
    [Route("api/account-admin/settings")]
	[Area("accountAdmin")]
	[ControllerName("Settings")]
	[RemoteService(true, Name = AccountProAdminRemoteServiceConsts.RemoteServiceName)]
	public class AccountSettingsController : AbpController, IAccountSettingsAppService, IRemoteService, IApplicationService
	{
		protected IAccountSettingsAppService AccountSettingsAppService { get; }

		public AccountSettingsController(IAccountSettingsAppService accountSettingsAppService)
		{
			this.AccountSettingsAppService = accountSettingsAppService;
		}

		[HttpGet]
		public virtual async Task<AccountSettingsDto> GetAsync()
		{
			return await this.AccountSettingsAppService.GetAsync();
		}

		[HttpPut]
		public virtual async Task UpdateAsync(AccountSettingsDto input)
		{
			await this.AccountSettingsAppService.UpdateAsync(input);
		}
	}
}
