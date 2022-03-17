using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.CactusTheme;
using Simple.Abp.CmsKit.Public.Web.Menu;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Pages;
using Volo.CmsKit.Public;

namespace Simple.Abp.CmsKit.Public.Web
{

    [DependsOn(
        typeof(AbpValidationModule),
        typeof(CmsKitPublicHttpApiClientModule),
        typeof(AbpAspNetCoreMvcUIThemeCactusModule),
        typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
        typeof(SimpleCmsKitPublicHttpApiClientModule)
    )]
    public class SimpleCmsKitPublicWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(SimpleCmsKitPublicWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SimpleCmsKitPublicWebModule>("Simple.Abp.CmsKit.Public.Web");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<CactusResource>().AddVirtualJson("Localization/SimpleCmsKit");
            });


            ConfigureNavigationServices(context);

            var cactusOptions =  configuration.GetSection("CactusTheme").Get<CactusOptions>();
            Configure<CactusOptions>(options =>
            {
                options.WebsiteFiling = cactusOptions?.WebsiteFiling; //"鲁ICP备19044904号-1";
                options.WebsiteFilingUrl = cactusOptions?.WebsiteFilingUrl; //"http://beian.miit.gov.cn";
                options.WebInfo = cactusOptions?.WebInfo; //"Copyright &copy; 2019-2022";
                options.CdnHost = cactusOptions?.CdnHost; //"https://ka-1252696628.cos.ap-beijing.myqcloud.com";
            });


            if (GlobalFeatureManager.Instance.IsEnabled<PagesFeature>())
            {
                Configure<RazorPagesOptions>(options =>
                {
                    options.Conventions.AddPageRoute("/Pages/Pages/Index", PageConsts.UrlPrefix + "{slug:minlength(1)}");

                    options.Conventions.AddPageRoute("/Blog", @"/blogs/{blogSlug:minlength(1)}");
                    options.Conventions.AddPageRoute("/Blog", "/blogs/{blogSlug:minlength(1)}/page/{pageIndex:int}");

                    options.Conventions.AddPageRoute("/Tag", @"/tags/{tagName:minlength(1)}");
                    options.Conventions.AddPageRoute("/Tag", @"/tags/{tagName:minlength(1)}/page/{pageIndex:int}");

                    options.Conventions.AddPageRoute("/BlogPost", @"/blogs/{blogSlug}/{blogPostSlug:minlength(1)}");
                });
            }
        }

        private void ConfigureNavigationServices(ServiceConfigurationContext context)
        {

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CmsKitMenuContributor(context));
            });
        }

    }
}
