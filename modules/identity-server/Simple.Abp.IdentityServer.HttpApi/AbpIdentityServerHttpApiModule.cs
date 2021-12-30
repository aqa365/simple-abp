﻿using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Simple.Abp.IdentityServer
{
	[DependsOn(
		typeof(AbpIdentityServerApplicationContractsModule),
		typeof(AbpAspNetCoreMvcModule)
	)]
	public class AbpIdentityServerHttpApiModule : AbpModule
	{
		public override void PreConfigureServices(ServiceConfigurationContext context)
		{
			PreConfigure<IMvcBuilder>(mvcBuilder =>
			{
				mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpIdentityServerHttpApiModule).Assembly);
			});
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources.Get<AbpIdentityServerResource>().AddBaseTypes(typeof(AbpUiResource));
			});
		}
	}
}
