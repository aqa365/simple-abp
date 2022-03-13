using Simple.Abp.CmsKit.Public.Web;
using Simple.Abp.Test;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Simple.Abp.CmsKit.Web
{

    [DependsOn(
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
