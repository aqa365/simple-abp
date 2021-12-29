using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IIdentityUserAppService : ICrudAppService<IdentityUserDto, Guid, GetIdentityUsersInput, IdentityUserCreateDto, IdentityUserUpdateDto>, ICrudAppService<IdentityUserDto, IdentityUserDto, Guid, GetIdentityUsersInput, IdentityUserCreateDto, IdentityUserUpdateDto>, IApplicationService, IRemoteService
	{
		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);

		Task<List<IdentityUserClaimDto>> GetClaimsAsync(Guid id);

		Task<List<OrganizationUnitDto>> GetOrganizationUnitsAsync(Guid id);

		Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

		Task UpdateClaimsAsync(Guid id, List<IdentityUserClaimDto> input);

		Task UpdatePasswordAsync(Guid id, IdentityUserUpdatePasswordInput input);

		Task UnlockAsync(Guid id);

		Task<IdentityUserDto> FindByUsernameAsync(string username);

		Task<IdentityUserDto> FindByEmailAsync(string email);
	}
}
