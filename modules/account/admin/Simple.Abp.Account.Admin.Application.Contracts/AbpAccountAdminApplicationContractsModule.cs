using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
    [DependsOn(
		typeof(AbpAccountSharedApplicationContractsModule)
	)]
	public class AbpAccountAdminApplicationContractsModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
		}
	}
}
