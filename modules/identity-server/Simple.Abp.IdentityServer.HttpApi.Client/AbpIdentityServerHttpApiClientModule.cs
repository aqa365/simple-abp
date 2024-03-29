﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.IdentityServer
{
    [DependsOn(
		typeof(AbpIdentityServerApplicationContractsModule)
	)]
	public class AbpIdentityServerHttpApiClientModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddHttpClientProxies(typeof(AbpIdentityServerApplicationContractsModule).Assembly, IdentityServerRemoteServiceConsts.RemoteServiceName);
		}
	}
}
