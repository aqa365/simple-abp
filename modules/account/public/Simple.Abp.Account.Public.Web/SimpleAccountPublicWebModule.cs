using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity1;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

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
            context.Services.AddScoped(typeof(Microsoft.AspNetCore.Identity1.SignInManager<IdentityUser>));
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



            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SimpleAccountPublicWebModule>
                    ("Simple.Abp.Account.Public.Web");
            });
        }
    }
}
