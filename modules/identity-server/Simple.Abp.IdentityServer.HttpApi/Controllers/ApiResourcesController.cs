using Microsoft.AspNetCore.Mvc;
using Simple.Abp.IdentityServer.ApiResources;
using Simple.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace Simple.Abp.IdentityServer
{
    [Controller]
	[ControllerName("ApiResources")]
	[Route("api/identity-server/api-resources")]
	[RemoteService(true, Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
	[Area("identityServer")]
	public class ApiResourcesController : AbpController, IApiResourceAppService, IRemoteService, IApplicationService
	{
		protected IApiResourceAppService ApiResourceAppService { get; }

		public ApiResourcesController(IApiResourceAppService apiResourceAppService)
		{
			this.ApiResourceAppService = apiResourceAppService;
		}

		[Route("")]
		[HttpGet]
		public virtual Task<PagedResultDto<ApiResourceWithDetailsDto>> GetListAsync(GetApiResourceListInput input)
		{
			return this.ApiResourceAppService.GetListAsync(input);
		}

		[HttpGet]
		[Route("all")]
		public virtual Task<List<ApiResourceWithDetailsDto>> GetAllListAsync()
		{
			return this.ApiResourceAppService.GetAllListAsync();
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<ApiResourceWithDetailsDto> GetAsync(Guid id)
		{
			return this.ApiResourceAppService.GetAsync(id);
		}

		[HttpPost]
		public virtual Task<ApiResourceWithDetailsDto> CreateAsync(CreateApiResourceDto input)
		{
			return this.ApiResourceAppService.CreateAsync(input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<ApiResourceWithDetailsDto> UpdateAsync(Guid id, UpdateApiResourceDto input)
		{
			return this.ApiResourceAppService.UpdateAsync(id, input);
		}

		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.ApiResourceAppService.DeleteAsync(id);
		}
	}
}
