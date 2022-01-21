using Simple.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService :IApplicationService
	{
		Task<PagedResultDto<ApiResourceWithDetailsDto>> GetListAsync(GetApiResourceListInput input);

		Task<List<ApiResourceWithDetailsDto>> GetAllListAsync();

		Task<ApiResourceWithDetailsDto> GetAsync(Guid id);

		Task<ApiResourceWithDetailsDto> CreateAsync(CreateApiResourceDto input);

		Task<ApiResourceWithDetailsDto> UpdateAsync(Guid id, UpdateApiResourceDto input);

		Task DeleteAsync(Guid id);
	}
}
