using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
    [DependsOn(new Type[]
	{
		typeof(AbpAccountAdminApplicationContractsModule),
		typeof(AbpHttpClientModule)
	})]
	public class AbpAccountAdminHttpApiClientModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddHttpClientProxies(typeof(AbpAccountAdminApplicationContractsModule).Assembly, AccountProAdminRemoteServiceConsts.RemoteServiceName);
		}
	}
}
