using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Simple.Abp.Account.PhoneNumber
{
	public interface IAccountPhoneService
	{
		Task SendConfirmationCodeAsync(IdentityUser user, string confirmationToken);
	}
}
