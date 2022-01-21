using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Simple.Abp.IdentityServer.ClaimTypes.Dtos;

namespace Volo.Abp.IdentityServer.ClaimTypes
{
	public interface IIdentityServerClaimTypeAppService : IApplicationService
	{
		Task<List<IdentityClaimTypeDto>> GetListAsync();
	}
}
