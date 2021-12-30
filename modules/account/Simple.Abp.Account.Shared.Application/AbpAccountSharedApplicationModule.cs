using Simple.Abp.Identity;
using Volo.Abp.Emailing;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.Account
{
	[DependsOn(
		typeof(AbpAccountSharedApplicationContractsModule),
		typeof(AbpEmailingModule),
		typeof(AbpIdentityApplicationModule),
		typeof(AbpUiNavigationModule)
	)]
	public class AbpAccountSharedApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
		}
	}
}
