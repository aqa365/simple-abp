using Simple.Abp.Account;
using Simple.Abp.Articles;
using Simple.Abp.AuditLogging;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.Test
{

    [DependsOn(
        typeof(SimpleTestDomainSharedModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule),
        typeof(AbpArticlesApplicationContractsModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class SimpleTestApplicationContractsModule:AbpModule
    {

    }
}
