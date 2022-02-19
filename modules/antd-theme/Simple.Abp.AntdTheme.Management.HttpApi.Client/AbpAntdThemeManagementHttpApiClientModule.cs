using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.AntdTheme
{
    [DependsOn(
        typeof(AbpAntdThemeManagementApplicationContractsModule)
    )]
    public class AbpAntdThemeManagementHttpApiClientModule:AbpModule
    {
        public const string RemoteServiceName = "AbpAntdTheme";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpAntdThemeManagementHttpApiClientModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
