using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IIdentityRoleAppService : IApplicationService, IRemoteService
	{
		Task<ListResultDto<IdentityRoleDto>> GetAllListAsync();

		Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRoleListInput input);

		Task UpdateClaimsAsync(Guid id, List<IdentityRoleClaimDto> input);

		Task<List<IdentityRoleClaimDto>> GetClaimsAsync(Guid id);

		Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input);

		Task<IdentityRoleDto> GetAsync(Guid id);

		Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input);

		Task DeleteAsync(Guid id);
	}
}
