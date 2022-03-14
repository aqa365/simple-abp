using Simple.Abp.CmsKit.Public;
using Simple.Abp.CmsKit.Public.Web;
using Simple.Abp.Test;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.Authentication.OpenIdConnect;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.Web;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace Simple.Abp.CmsKit.Web
{

    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpHttpClientWebModule),
        typeof(AbpAspNetCoreAuthenticationOAuthModule),
        typeof(AbpAspNetCoreAuthenticationOpenIdConnectModule),
        typeof(SimpleCmsKitPublicWebModule),
        typeof(SimpleTestHttpApiClientModule)
    )]
    public class SimpleTestCmsKitWebModule : AbpModule
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

            Configure<AbpJsonOptions>(options => options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss");

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseConfiguredEndpoints();
        }
    }
}
