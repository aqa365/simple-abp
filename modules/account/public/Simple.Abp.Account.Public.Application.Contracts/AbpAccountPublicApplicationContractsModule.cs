using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
	[DependsOn(
		typeof(AbpAccountSharedApplicationContractsModule)
	)]
	public class AbpAccountPublicApplicationContractsModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
		}
	}
}
