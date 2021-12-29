using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
	[Route("/api/identity/my-profile")]
	[ControllerName("Profile")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class ProfileController : AbpController, IProfileAppService, IApplicationService, IRemoteService
	{
		protected IProfileAppService ProfileAppService { get; }

		public ProfileController(IProfileAppService profileAppService)
		{
			ProfileAppService = profileAppService;
		}

		[HttpGet]
		public virtual Task<ProfileDto> GetAsync()
		{
			return this.ProfileAppService.GetAsync();
		}

		[HttpPut]
		public virtual Task<ProfileDto> UpdateAsync(UpdateProfileDto input)
		{
			return this.ProfileAppService.UpdateAsync(input);
		}

		[Route("change-password")]
		[HttpPost]
		public virtual Task ChangePasswordAsync(ChangePasswordInput input)
		{
			return this.ProfileAppService.ChangePasswordAsync(input);
		}
	}
}
