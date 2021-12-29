using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Simple.Abp.IdentityServer.ClaimTypes.Dtos;
using Volo.Abp.IdentityServer;
using Volo.Abp;
using Volo.Abp.IdentityServer.ClaimTypes;

namespace Simple.Abp.IdentityServer.ClaimTypes
{
	public class IdentityServerClaimTypeAppService : IdentityServerAppServiceBase, IRemoteService, IApplicationService, IIdentityServerClaimTypeAppService
	{
		protected IIdentityClaimTypeRepository ClaimTypeRepository { get; }

		public IdentityServerClaimTypeAppService(IIdentityClaimTypeRepository claimTypeRepository)
		{
			this.ClaimTypeRepository = claimTypeRepository;
		}

		public virtual async Task<List<IdentityClaimTypeDto>> GetListAsync()
		{
			List<IdentityClaimType> list = await this.ClaimTypeRepository.GetListAsync();
			return base.ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(list);
		}
	}
}
