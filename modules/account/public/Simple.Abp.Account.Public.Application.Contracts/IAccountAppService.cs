using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Simple.Abp.Identity;

namespace Simple.Abp.Account
{
	public interface IAccountAppService : IApplicationService
	{
		Task<IdentityUserDto> RegisterAsync(RegisterDto input);

		Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input);

		Task ResetPasswordAsync(ResetPasswordDto input);

		Task SendPhoneNumberConfirmationTokenAsync();

		Task ConfirmPhoneNumberAsync(ConfirmPhoneNumberInput input);

		Task ConfirmEmailAsync(ConfirmEmailInput input);
	}
}
