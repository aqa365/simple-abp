using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.CactusTheme;
using Simple.Abp.CmsKit.Public.Web.Menu;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Public;

namespace Simple.Abp.CmsKit.Public.Web
{

    [DependsOn(
        typeof(CmsKitPublicHttpApiClientModule),
        typeof(AbpAspNetCoreMvcUIThemeCactusModule ),
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

            ConfigureNavigationServices(configuration);
            Configure<CactusOptions>(options =>
            {
                options.WebsiteFiling = "鲁ICP备19044904号-1";
                options.WebsiteFilingUrl = "http://beian.miit.gov.cn";
                options.WebInfo = "Copyright &copy; 2019-2022";
                //options.CdnHost = "https://ka-1252696628.cos.ap-beijing.myqcloud.com";
            });


            Configure<RazorPagesOptions>(options =>
            {
                options.Conventions.AddPageRoute("/Writing", "/writing/page/{pageIndex:int}");

                options.Conventions.AddPageRoute("/Writing", "/writing/catalog/{catalogTitle}");
                options.Conventions.AddPageRoute("/Writing", "/writing/catalog/{catalogTitle}/page/{pageIndex:int}");

                options.Conventions.AddPageRoute("/Writing", "/writing/tag/{tagName}");
                options.Conventions.AddPageRoute("/Writing", "/writing/tag/{tagName}/page/{pageIndex:int}");
            });
        }

        private void ConfigureNavigationServices(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new CmsKitMenuContributor(configuration));
            });
        }

    }
}
