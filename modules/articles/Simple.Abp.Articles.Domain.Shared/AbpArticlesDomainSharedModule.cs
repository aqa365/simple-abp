using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class AbpArticlesDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpArticlesDomainSharedModule>("Simple.Abp.Articles");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ArticlesResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("Localization/SimpleAbpArticles");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.Articles", typeof(ArticlesResource)));
        }
    }
}
