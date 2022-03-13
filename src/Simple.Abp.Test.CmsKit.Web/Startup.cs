using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.CmsKit.Web;

namespace Simple.Abp.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SimpleTestCmsKitWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
