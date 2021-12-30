using Volo.Abp.Modularity;
using Volo.Abp.Sms;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Account
{
	[DependsOn(
		typeof(AbpAccountSharedApplicationModule),
		typeof(AbpSmsModule)
	)]
	public class AbpAccountPublicApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpVirtualFileSystemOptions>(options => options.FileSets.AddEmbedded<AbpAccountPublicApplicationModule>());
			Configure<AppUrlOptions>(options =>
			 {
				 options.Applications["MVC"].Urls["Abp.Account.PasswordReset"] = "Account/ResetPassword";
				 options.Applications["MVC"].Urls["Abp.Account.EmailConfirmation"] = "Account/EmailConfirmation";
			 });
		}
	}
}
