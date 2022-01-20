using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IOrganizationUnitAppService : IApplicationService
	{
		Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id);

		Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(GetOrganizationUnitInput input);

		Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync();

		Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(Guid id, GetIdentityUsersInput input);

		Task RemoveMemberAsync(Guid id, Guid memberId);

		Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input);

		Task RemoveRoleAsync(Guid id, Guid roleId);

		Task<OrganizationUnitWithDetailsDto> CreateAsync(OrganizationUnitCreateDto input);

		Task DeleteAsync(Guid id);

		Task<OrganizationUnitWithDetailsDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input);

		Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input);

		Task AddMembersAsync(Guid id, OrganizationUnitUserInput input);

		Task MoveAsync(Guid id, OrganizationUnitMoveInput input);
	}
}
