using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
	[ControllerName("Role")]
	[Route("api/identity/roles")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Area("identity")]
	public class IdentityRoleController : AbpController, IIdentityRoleAppService
	{
		protected IIdentityRoleAppService RoleAppService { get; }

		public IdentityRoleController(IIdentityRoleAppService roleAppService)
		{
			RoleAppService = roleAppService;
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<IdentityRoleDto> GetAsync(Guid id)
		{
			return this.RoleAppService.GetAsync(id);
		}

		[HttpPost]
		public virtual Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
		{
			return this.RoleAppService.CreateAsync(input);
		}

		[Route("{id}")]
		[HttpPut]
		public virtual Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
		{
			return this.RoleAppService.UpdateAsync(id, input);
		}

		[HttpDelete]
		[Route("{id}")]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.RoleAppService.DeleteAsync(id);
		}

		[Route("all")]
		[HttpGet]
		public virtual Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
		{
			return this.RoleAppService.GetAllListAsync();
		}

		[HttpGet]
		public virtual Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRoleListInput input)
		{
			return this.RoleAppService.GetListAsync(input);
		}

		[HttpPut]
		[Route("{id}/claims")]
		public virtual Task UpdateClaimsAsync(Guid id, List<IdentityRoleClaimDto> input)
		{
			return this.RoleAppService.UpdateClaimsAsync(id, input);
		}

		[HttpGet]
		[Route("{id}/claims")]
		public virtual Task<List<IdentityRoleClaimDto>> GetClaimsAsync(Guid id)
		{
			return this.RoleAppService.GetClaimsAsync(id);
		}
	}
}
