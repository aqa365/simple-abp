using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
    [Route("api/identity/settings")]
	[ControllerName("Settings")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class IdentitySettingsController : AbpController, IIdentitySettingsAppService
	{
		protected IIdentitySettingsAppService IdentitySettingsAppService { get; }

		public IdentitySettingsController(IIdentitySettingsAppService identitySettingsAppService)
		{
			IdentitySettingsAppService = identitySettingsAppService;
		}

		[HttpGet]
		public virtual Task<IdentitySettingsDto> GetAsync()
		{
			return this.IdentitySettingsAppService.GetAsync();
		}

		[HttpPut]
		public virtual Task UpdateAsync(IdentitySettingsDto input)
		{
			return this.IdentitySettingsAppService.UpdateAsync(input);
		}
	}
}
