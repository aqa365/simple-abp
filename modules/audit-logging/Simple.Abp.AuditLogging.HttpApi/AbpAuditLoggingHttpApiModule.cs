using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Simple.Abp.AuditLogging
{
    [DependsOn(
		typeof(AbpAuditLoggingApplicationContractsModule),
		typeof(AbpAspNetCoreMvcModule)
	)]
	public class AbpAuditLoggingHttpApiModule : AbpModule
	{
		public override void PreConfigureServices(ServiceConfigurationContext context)
		{
			base.PreConfigure<IMvcBuilder>(delegate(IMvcBuilder mvcBuilder)
			{
				mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpAuditLoggingHttpApiModule).Assembly);
			});
		}

		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			base.Configure<AbpLocalizationOptions>(options=>
			{
				options.Resources.Get<AuditLoggingResource>().AddBaseTypes(typeof(AbpUiResource));
			});
		}
	}
}
