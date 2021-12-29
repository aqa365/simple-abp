using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Identity
{
	public interface IIdentitySettingsAppService : IApplicationService, IRemoteService
	{
		Task<IdentitySettingsDto> GetAsync();

		Task UpdateAsync(IdentitySettingsDto input);
	}
}
