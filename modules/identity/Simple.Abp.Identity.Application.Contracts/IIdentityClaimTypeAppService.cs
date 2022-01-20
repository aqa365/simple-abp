using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
    public interface IIdentityClaimTypeAppService : IApplicationService
	{
		Task<PagedResultDto<ClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input);

		Task<List<ClaimTypeDto>> GetAllListAsync();

		Task<ClaimTypeDto> GetAsync(Guid id);

		Task<ClaimTypeDto> CreateAsync(CreateClaimTypeDto input);

		Task<ClaimTypeDto> UpdateAsync(Guid id, UpdateClaimTypeDto input);

		Task DeleteAsync(Guid id);
	}
}
