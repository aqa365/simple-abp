using Microsoft.AspNetCore.Mvc;
using Simple.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.IdentityServer.Clients;

namespace Simple.Abp.IdentityServer
{
    [ControllerName("Clients")]
	[Route("api/identity-server/clients")]
	[RemoteService(true, Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
	[Area("identityServer")]
	[Controller]
	public class ClientsController : AbpController, IRemoteService, IApplicationService, IClientAppService
	{
		protected IClientAppService ClientAppService { get; }

		public ClientsController(IClientAppService clientAppService)
		{
			this.ClientAppService = clientAppService;
		}

		[HttpGet]
		public virtual Task<PagedResultDto<ClientWithDetailsDto>> GetListAsync(GetClientListInput input)
		{
			return this.ClientAppService.GetListAsync(input);
		}

		[HttpGet]
		[Route("{id}")]
		public virtual Task<ClientWithDetailsDto> GetAsync(Guid id)
		{
			return this.ClientAppService.GetAsync(id);
		}

		[HttpPost]
		public virtual Task<ClientWithDetailsDto> CreateAsync(CreateClientDto input)
		{
			return this.ClientAppService.CreateAsync(input);
		}

		[Route("{id}")]
		[HttpPut]
		public virtual Task<ClientWithDetailsDto> UpdateAsync(Guid id, UpdateClientDto input)
		{
			return this.ClientAppService.UpdateAsync(id, input);
		}

		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.ClientAppService.DeleteAsync(id);
		}
	}
}
