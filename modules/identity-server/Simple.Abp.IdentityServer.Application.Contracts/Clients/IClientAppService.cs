using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Simple.Abp.IdentityServer.Clients.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
	public interface IClientAppService : IRemoteService, IApplicationService
	{
		Task<PagedResultDto<ClientWithDetailsDto>> GetListAsync(GetClientListInput input);

		Task<ClientWithDetailsDto> GetAsync(Guid id);

		Task<ClientWithDetailsDto> CreateAsync(CreateClientDto input);

		Task<ClientWithDetailsDto> UpdateAsync(Guid id, UpdateClientDto input);

		Task DeleteAsync(Guid id);
	}
}
