using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Simple.Abp.Identity
{
    [DependsOn(
		typeof(AbpIdentityApplicationContractsModule),
		typeof(AbpHttpClientModule)
	)]
	public class AbpIdentityHttpApiClientModule : AbpModule
	{
		public static readonly string Development;

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddHttpClientProxies(typeof(AbpIdentityApplicationContractsModule).Assembly, IdentityProRemoteServiceConsts.RemoteServiceName);
		}

		static AbpIdentityHttpApiClientModule()
		{
			Development = "Development";
		}
	}
}
