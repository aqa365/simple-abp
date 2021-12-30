using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using Simple.Abp.Account.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Simple.Abp.Account
{
    [DependsOn(
		typeof(AbpAccountAdminApplicationContractsModule),
		typeof(AbpAspNetCoreMvcModule)
	)]
	public class AbpAccountAdminHttpApiModule : AbpModule
	{
		public override void PreConfigureServices(ServiceConfigurationContext context)
		{
			base.PreConfigure<IMvcBuilder>(mvcBuilder =>
			{
				mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAccountAdminHttpApiModule).Assembly);
			});
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			base.Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources.Get<AccountResource>()
				.AddBaseTypes(new Type[]
				{
					typeof(AbpUiResource)
				});
			});
		}
	}
}
