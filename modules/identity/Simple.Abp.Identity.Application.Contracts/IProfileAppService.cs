using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IProfileAppService : IApplicationService
	{
		Task<ProfileDto> GetAsync();

		Task<ProfileDto> UpdateAsync(UpdateProfileDto input);

		Task ChangePasswordAsync(ChangePasswordInput input);
	}
}
