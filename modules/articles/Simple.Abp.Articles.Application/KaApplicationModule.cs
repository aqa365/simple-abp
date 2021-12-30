using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpArticlesDomainModule),
        typeof(AbpArticlesApplicationContractsModule)
    )]
    public class KaApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<KaApplicationModule>();
            });
        }
    }
}
