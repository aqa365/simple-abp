using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
    [ControllerName("User")]
	[Route("api/identity/users")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class IdentityUserController : AbpController, IIdentityUserAppService
	{
		protected IIdentityUserAppService UserAppService { get; }

		public IdentityUserController(IIdentityUserAppService userAppService)
		{
			UserAppService = userAppService;
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<IdentityUserDto> GetAsync(Guid id)
		{
			return this.UserAppService.GetAsync(id);
		}

		[HttpGet]
		public virtual Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
		{
			return this.UserAppService.GetListAsync(input);
		}

		[HttpGet]
		[Route("assignable-roles")]
		public Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
		{
			return UserAppService.GetAssignableRolesAsync();
		}

		[HttpGet]
		[Route("available-organization-units")]
		public Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetAvailableOrganizationUnitsAsync()
		{
			return UserAppService.GetAvailableOrganizationUnitsAsync();
		}

		[HttpPost]
		public virtual Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
		{
			return this.UserAppService.CreateAsync(input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
		{
			return this.UserAppService.UpdateAsync(id, input);
		}

		[HttpDelete]
		[Route("{id}")]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.UserAppService.DeleteAsync(id);
		}

		[Route("{id}/roles")]
		[HttpGet]
		public virtual Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
		{
			return this.UserAppService.GetRolesAsync(id);
		}

		[Route("{id}/claims")]
		[HttpGet]
		public virtual Task<List<IdentityUserClaimDto>> GetClaimsAsync(Guid id)
		{
			return this.UserAppService.GetClaimsAsync(id);
		}

		[HttpGet]
		[Route("{id}/organization-units")]
		public virtual Task<List<OrganizationUnitDto>> GetOrganizationUnitsAsync(Guid id)
		{
			return this.UserAppService.GetOrganizationUnitsAsync(id);
		}

		[HttpPut]
		[Route("{id}/roles")]
		public virtual Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
		{
			return this.UserAppService.UpdateRolesAsync(id, input);
		}

		[Route("{id}/claims")]
		[HttpPut]
		public virtual Task UpdateClaimsAsync(Guid id, List<IdentityUserClaimDto> input)
		{
			return this.UserAppService.UpdateClaimsAsync(id, input);
		}

		[Route("{id}/unlock")]
		[HttpPut]
		public virtual Task UnlockAsync(Guid id)
		{
			return this.UserAppService.UnlockAsync(id);
		}

		[Route("by-username/{username}")]
		[HttpGet]
		public virtual Task<IdentityUserDto> FindByUsernameAsync(string username)
		{
			return this.UserAppService.FindByUsernameAsync(username);
		}

		[HttpGet]
		[Route("by-email/{email}")]
		public virtual Task<IdentityUserDto> FindByEmailAsync(string email)
		{
			return this.UserAppService.FindByEmailAsync(email);
		}

		[Route("{id}/change-password")]
		[HttpPut]
		public virtual Task UpdatePasswordAsync(Guid id, IdentityUserUpdatePasswordInput input)
		{
			return this.UserAppService.UpdatePasswordAsync(id, input);
		}
    }
}
