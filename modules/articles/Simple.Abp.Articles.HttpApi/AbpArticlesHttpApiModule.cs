using Localization.Resources.AbpUi;
using Simple.Abp.Articles;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpArticlesApplicationContractsModule)
    )]
    public class AbpArticlesHttpApiModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ArticlesResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
