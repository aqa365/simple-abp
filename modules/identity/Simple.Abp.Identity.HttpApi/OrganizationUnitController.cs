using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
	[Route("api/identity/organization-units")]
	[ControllerName("OrganizationUnit")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class OrganizationUnitController : AbpController, IOrganizationUnitAppService, IApplicationService, IRemoteService
	{
		protected IOrganizationUnitAppService OrganizationUnitAppService { get; }

		public OrganizationUnitController(IOrganizationUnitAppService organizationUnitAppService)
		{
			OrganizationUnitAppService = organizationUnitAppService;
		}

		[Route("{id}/roles")]
		[HttpPut]
		public virtual Task AddRolesAsync(Guid id, OrganizationUnitRoleInput input)
		{
			return this.OrganizationUnitAppService.AddRolesAsync(id, input);
		}

		[Route("{id}/members")]
		[HttpPut]
		public virtual Task AddMembersAsync(Guid id, OrganizationUnitUserInput input)
		{
			return this.OrganizationUnitAppService.AddMembersAsync(id, input);
		}

		[HttpPost]
		public virtual Task<OrganizationUnitWithDetailsDto> CreateAsync(OrganizationUnitCreateDto input)
		{
			return this.OrganizationUnitAppService.CreateAsync(input);
		}

		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.OrganizationUnitAppService.DeleteAsync(id);
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<OrganizationUnitWithDetailsDto> GetAsync(Guid id)
		{
			return this.OrganizationUnitAppService.GetAsync(id);
		}

		[HttpGet]
		public virtual Task<PagedResultDto<OrganizationUnitWithDetailsDto>> GetListAsync(GetOrganizationUnitInput input)
		{
			return this.OrganizationUnitAppService.GetListAsync(input);
		}

		[HttpGet]
		[Route("all")]
		public virtual Task<ListResultDto<OrganizationUnitWithDetailsDto>> GetListAllAsync()
		{
			return this.OrganizationUnitAppService.GetListAllAsync();
		}

		[Route("{id}/roles")]
		[HttpGet]
		public virtual Task<PagedResultDto<IdentityRoleDto>> GetRolesAsync(Guid id, PagedAndSortedResultRequestDto input)
		{
			return this.OrganizationUnitAppService.GetRolesAsync(id, input);
		}

		[Route("{id}/members")]
		[HttpGet]
		public virtual Task<PagedResultDto<IdentityUserDto>> GetMembersAsync(Guid id, GetIdentityUsersInput input)
		{
			return this.OrganizationUnitAppService.GetMembersAsync(id, input);
		}

		[Route("{id}/move")]
		[HttpPut]
		public virtual Task MoveAsync(Guid id, OrganizationUnitMoveInput input)
		{
			return this.OrganizationUnitAppService.MoveAsync(id, input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<OrganizationUnitWithDetailsDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
		{
			return this.OrganizationUnitAppService.UpdateAsync(id, input);
		}

		[Route("{id}/members/{memberId}")]
		[HttpDelete]
		public virtual Task RemoveMemberAsync(Guid id, Guid memberId)
		{
			return this.OrganizationUnitAppService.RemoveMemberAsync(id, memberId);
		}

		[Route("{id}/roles/{roleId}")]
		[HttpDelete]
		public virtual Task RemoveRoleAsync(Guid id, Guid roleId)
		{
			return this.OrganizationUnitAppService.RemoveRoleAsync(id, roleId);
		}
	}
}
