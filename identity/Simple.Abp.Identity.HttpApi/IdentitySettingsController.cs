using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
	[Route("api/identity/settings")]
	[ControllerName("Settings")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class IdentitySettingsController : AbpController, IIdentitySettingsAppService, IApplicationService, IRemoteService
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
