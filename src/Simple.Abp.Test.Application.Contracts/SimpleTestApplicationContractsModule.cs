using Simple.Abp.Account;
using Simple.Abp.AntdTheme;
using Simple.Abp.Articles;
using Simple.Abp.AuditLogging;
using Simple.Abp.CloudStorage;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.Test
{

    [DependsOn(
        typeof(SimpleTestDomainSharedModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpArticlesApplicationContractsModule),
        typeof(AbpCloudStorageApplicationContractsModule),
        typeof(AbpAntdThemeManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class SimpleTestApplicationContractsModule:AbpModule
    {

    }
}
