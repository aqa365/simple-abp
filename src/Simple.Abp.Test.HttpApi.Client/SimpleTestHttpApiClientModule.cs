using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Account;
using Simple.Abp.AntdTheme;
using Simple.Abp.AuditLogging;
using Simple.Abp.CloudStorage;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.CmsKit;

namespace Simple.Abp.Test
{
    [DependsOn(
        typeof(SimpleTestApplicationContractsModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpIdentityServerHttpApiClientModule),
        typeof(AbpAuditLoggingHttpApiClientModule),
        typeof(AbpAccountAdminHttpApiClientModule),
        typeof(AbpAccountPublicHttpApiClientModule),
        typeof(AbpCloudStorageHttpClientModule),
        typeof(AbpAntdThemeManagementHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(CmsKitHttpApiClientModule)
    )]
    public class SimpleTestHttpApiClientModule:AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SimpleTestApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
