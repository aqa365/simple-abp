using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Articles.Web.Theme.Cactus
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule)
    )]
    public class AbpArticlesWebThemeCactusModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(AbpArticlesWebThemeCactusModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<CactusTheme>();
                options.DefaultThemeName = CactusTheme.Name;
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpArticlesWebThemeCactusModule>("Simple.Abp.Articles.Web.Theme.Cactus");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<CactusResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("Localization/SimpleAbpArticlesCactus");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.Articles.Web.Theme.Cactus", typeof(CactusResource)));
        }

    }
}
