using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.CloudStorage
{
    [DependsOn(
        typeof(AbpCloudStorageApplicationContractsModule)
    )]
    public class AbpCloudStorageHttpClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpCloudStorageApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
