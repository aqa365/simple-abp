using Simple.Abp.Account;
using Simple.Abp.AntdTheme;
using Simple.Abp.Articles;
using Simple.Abp.AuditLogging;
using Simple.Abp.CloudStorage;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.Test
{
    [DependsOn(
        typeof(SimpleTestDomainModule),
        typeof(SimpleTestApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityServerApplicationModule),
        typeof(AbpAuditLoggingApplicationModule),
        typeof(AbpAccountAdminApplicationModule),
        typeof(AbpAccountPublicApplicationModule),
        typeof(AbpArticlesApplicationModule),
        typeof(AbpCloudStorageApplicationModule),
        typeof(AbpAntdThemeManagementApplicationModule),
        typeof(AbpPermissionManagementApplicationModule)
    )]
    public class SimpleTestApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SimpleTestApplicationModule>();
            });
        }
    }
}
