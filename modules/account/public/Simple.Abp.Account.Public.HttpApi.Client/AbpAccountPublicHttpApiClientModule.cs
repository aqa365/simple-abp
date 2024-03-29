﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
	[DependsOn(
		typeof(AbpAccountPublicApplicationContractsModule),
		typeof(AbpHttpClientModule)
	)]
	public class AbpAccountPublicHttpApiClientModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddHttpClientProxies(typeof(AbpAccountPublicApplicationContractsModule).Assembly, AccountProPublicRemoteServiceConsts.RemoteServiceName);
		}
	}
}
