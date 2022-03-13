using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.CmsKit.Public
{
    [DependsOn(
         typeof(SimpleCmsKitPublicApplicationContractsModule)
    )]
    public class SimpleCmsKitPublicHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "SimpleCmsKitPublic";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SimpleCmsKitPublicHttpApiClientModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
