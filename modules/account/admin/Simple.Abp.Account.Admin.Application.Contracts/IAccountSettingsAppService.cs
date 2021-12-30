using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Account
{
    public interface IAccountSettingsAppService : IRemoteService, IApplicationService
	{
		Task<AccountSettingsDto> GetAsync();

		Task UpdateAsync(AccountSettingsDto input);
	}
}
