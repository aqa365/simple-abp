using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.CmsKit.Public;

namespace Simple.Abp.CmsKit.Public
{
    [DependsOn(
         typeof(SimpleCmsKitPublicApplicationContractsModule)
    )]
    public class SimpleCmsKitPublicHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SimpleCmsKitPublicApplicationContractsModule).Assembly,
                CmsKitPublicRemoteServiceConsts.RemoteServiceName
            );

            //context.Services.AddHttpClientProxies(
            //    typeof(SimpleCmsKitPublicHttpApiClientModule).Assembly,
            //    RemoteServiceName
            //);
        }
    }
}
