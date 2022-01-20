using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IIdentitySettingsAppService : IApplicationService
	{
		Task<IdentitySettingsDto> GetAsync();

		Task UpdateAsync(IdentitySettingsDto input);
	}
}
