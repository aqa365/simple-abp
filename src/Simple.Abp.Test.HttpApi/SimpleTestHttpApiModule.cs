using Localization.Resources.AbpUi;
using Simple.Abp.Account;
using Simple.Abp.AntdTheme;
using Simple.Abp.AuditLogging;
using Simple.Abp.CloudStorage;
using Simple.Abp.CmsKit.Public;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.CmsKit;

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
        typeof(AbpCloudStorageHttpApiModule),
        typeof(AbpAntdThemeManagementHttpApiModule),
        typeof(CmsKitHttpApiModule),
        typeof(SimpleCmsKitPublicHttpApiModule)
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
