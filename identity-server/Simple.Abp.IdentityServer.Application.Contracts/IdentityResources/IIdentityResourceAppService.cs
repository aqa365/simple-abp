using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Simple.Abp.IdentityServer.IdentityResources.Dtos;
using Volo.Abp;

namespace Simple.Abp.IdentityServer.IdentityResources
{
	public interface IIdentityResourceAppService : IRemoteService, IApplicationService
	{
		Task<PagedResultDto<IdentityResourceWithDetailsDto>> GetListAsync(GetIdentityResourceListInput input);

		Task<List<IdentityResourceWithDetailsDto>> GetAllListAsync();

		Task<IdentityResourceWithDetailsDto> GetAsync(Guid id);

		Task<IdentityResourceWithDetailsDto> CreateAsync(CreateIdentityResourceDto input);

		Task<IdentityResourceWithDetailsDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input);

		Task DeleteAsync(Guid id);

		Task CreateStandardResourcesAsync();
	}
}
