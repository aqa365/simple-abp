using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles.Public.Web.Menus;
using Simple.Abp.Articles.Web.Theme.Cactus;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Articles.Public.Web
{

    [DependsOn(
        typeof(AbpArticlesHttpApiClientModule),
        typeof(AbpArticlesWebThemeCactusModule),
        typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule)
    )]
    public class AbpArticlesPublicWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {         
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(AbpArticlesPublicWebModule).Assembly);
            });
        }


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpArticlesPublicWebModule>("Simple.Abp.Articles.Public.Web");
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
                options.MenuContributors.Add(new ArticlesMenuContributor(configuration));
            });
        }

    }
}
