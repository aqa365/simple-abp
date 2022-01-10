using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Account.Public.Web
{
    [DependsOn(
      typeof(AbpAccountPublicHttpApiModule),
      typeof(AbpIdentityAspNetCoreModule),
      typeof(AbpAutoMapperModule),
      typeof(AbpAspNetCoreMvcUiThemeSharedModule)
      )]
    public class SimpleAccountPublicWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(
                    typeof(SimpleAccountPublicWebModule).Assembly);
            });

            // TODO 临时处理 需要挪到identityserverweb项目下
            context.Services
               .AddAuthentication(o =>
               {
                   o.DefaultScheme = IdentityConstants.ApplicationScheme;
                   o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
               })
               .AddIdentityCookies();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpThemingOptions>(options =>
            {
                options.Themes.Add<SimpleAccountPublicTheme>();
                options.DefaultThemeName = SimpleAccountPublicTheme.Name;
            });


            Configure<SimpleAccountPublicWebOptions>(options =>
            {
                options.WebsiteFiling = "Simple Abp";
                options.WebsiteFilingUrl = "http://beian.miit.gov.cn";
                options.WebInfo = "Copyright &copy; 2019-2022";

                options.LoginPageOptions = new LoginPageOptions
                {
                    LogoUrl = "/logo.png",
                    PageTitle = "Simple Abp",
                    MainTitle = "Simple Abp"
                };
            });


            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SimpleAccountPublicWebModule>
                    ("Simple.Abp.Account.Public.Web");
            });
        }
    }
}
