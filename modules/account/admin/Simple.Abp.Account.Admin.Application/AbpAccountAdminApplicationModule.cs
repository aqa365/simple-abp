using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
    [DependsOn(
		typeof(AbpAccountSharedApplicationModule)
	)]
	public class AbpAccountAdminApplicationModule : AbpModule
	{
	}
}
