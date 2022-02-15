using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Account;
using Simple.Abp.Articles;
using Simple.Abp.AuditLogging;
using Simple.Abp.CloudStorage;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Simple.Abp.Test
{
    [DependsOn(
        typeof(SimpleTestApplicationContractsModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpIdentityServerHttpApiModule),
        typeof(AbpAuditLoggingHttpApiModule),
        typeof(AbpAccountAdminHttpApiModule),
        typeof(AbpAccountPublicHttpApiModule),
        typeof(AbpArticlesHttpApiModule),
        typeof(AbpCloudStorageHttpApiModule)
    )]
    public class SimpleTestHttpApiModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SimpleTestResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
