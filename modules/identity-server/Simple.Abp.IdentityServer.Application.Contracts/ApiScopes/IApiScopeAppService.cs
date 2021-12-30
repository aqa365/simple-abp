using Simple.Abp.IdentityServer.ApiScopes.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.IdentityServer.ApiScopes
{
    public interface IApiScopeAppService:IRemoteService, IApplicationService
    {
        Task<PagedResultDto<ApiScopeDto>> GetListAsync(GetApiScopeListInput input);

        Task<List<ApiScopeDto>> GetAllListAsync();

        Task<ApiScopeDto> GetAsync(Guid id);

        Task<ApiScopeDto> CreateAsync(CreateApiScopeDto input);

        Task<ApiScopeDto> UpdateAsync(Guid id, UpdateApiScopeDto input);

        Task DeleteAsync(Guid id);
    }
}
