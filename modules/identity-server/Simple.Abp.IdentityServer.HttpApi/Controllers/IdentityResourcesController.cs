using Microsoft.AspNetCore.Mvc;
using Simple.Abp.IdentityServer.IdentityResources;
using Simple.Abp.IdentityServer.IdentityResources.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace Simple.Abp.IdentityServer
{
    [ControllerName("IdentityResources")]
	[Route("api/identity-server/identity-resources")]
	[RemoteService(true, Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
	[Area("identityServer")]
	[Controller]
	public class IdentityResourcesController : AbpController, IRemoteService, IApplicationService, IIdentityResourceAppService
	{
		protected IIdentityResourceAppService IdentityResourceAppService { get; }

		public IdentityResourcesController(IIdentityResourceAppService identityResourceAppService)
		{
			this.IdentityResourceAppService = identityResourceAppService;
		}

		[Route("")]
		[HttpGet]
		public Task<PagedResultDto<IdentityResourceWithDetailsDto>> GetListAsync(GetIdentityResourceListInput input)
		{
			return this.IdentityResourceAppService.GetListAsync(input);
		}

		[Route("all")]
		[HttpGet]
		public virtual Task<List<IdentityResourceWithDetailsDto>> GetAllListAsync()
		{
			return this.IdentityResourceAppService.GetAllListAsync();
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<IdentityResourceWithDetailsDto> GetAsync(Guid id)
		{
			return this.IdentityResourceAppService.GetAsync(id);
		}

		[HttpPost]
		public virtual Task<IdentityResourceWithDetailsDto> CreateAsync(CreateIdentityResourceDto input)
		{
			return this.IdentityResourceAppService.CreateAsync(input);
		}

		[Route("{id}")]
		[HttpPut]
		public virtual Task<IdentityResourceWithDetailsDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input)
		{
			return this.IdentityResourceAppService.UpdateAsync(id, input);
		}

		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.IdentityResourceAppService.DeleteAsync(id);
		}

		[Route("create-standard-resources")]
		[HttpPost]
		public virtual Task CreateStandardResourcesAsync()
		{
			return this.IdentityResourceAppService.CreateStandardResourcesAsync();
		}
	}
}
