using System.Threading.Tasks;
using Volo.Abp.UI.Navigation.Urls;

namespace Simple.Abp.Account.Emailing
{
	public static class AppUrlProviderAccountExtensions
	{
		public static Task<string> GetResetPasswordUrlAsync(this IAppUrlProvider appUrlProvider, string appName)
		{
			return appUrlProvider.GetUrlAsync(appName, "Abp.Account.PasswordReset");
		}

		public static Task<string> GetEmailConfirmationUrlAsync(this IAppUrlProvider appUrlProvider, string appName)
		{
			return appUrlProvider.GetUrlAsync(appName, "Abp.Account.EmailConfirmation");
		}
	}
}
