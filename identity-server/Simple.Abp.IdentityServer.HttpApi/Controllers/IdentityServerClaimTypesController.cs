using Microsoft.AspNetCore.Mvc;
using Simple.Abp.IdentityServer.ClaimTypes.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.IdentityServer.ClaimTypes;

namespace Simple.Abp.IdentityServer
{
    [Controller]
	[ControllerName("ClaimTypes")]
	[Route("api/identity-server/claim-types")]
	[RemoteService(true, Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
	[Area("identityServer")]
	public class IdentityServerClaimTypesController : AbpController, IRemoteService, IApplicationService, IIdentityServerClaimTypeAppService
	{
		protected IIdentityServerClaimTypeAppService ClaimTypeAppService { get; }

		public IdentityServerClaimTypesController(IIdentityServerClaimTypeAppService claimTypeAppService)
		{
			this.ClaimTypeAppService = claimTypeAppService;
		}

		[HttpGet]
		public virtual Task<List<IdentityClaimTypeDto>> GetListAsync()
		{
			return this.ClaimTypeAppService.GetListAsync();
		}
	}
}
