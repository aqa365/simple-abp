using Simple.Abp.Shared;
using Volo.Abp.Application;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Authorization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.AuditLogging
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(AbpAuditLoggingDomainSharedModule),
        typeof(SimpleAbpSharedApplicationContractsModule)
    )]
    public class AbpAuditLoggingApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
                options.FileSets.AddEmbedded<AbpAuditLoggingApplicationContractsModule>("Simple.Abp.AuditLogging"));

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Get<AuditLoggingResource>()
                .AddBaseTypes(typeof(SimpleAbpSharedApplicationContractsModule))
                .AddVirtualJson("Localization/SimpleAbpAuditLogging");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.AuditLogging", typeof(AuditLoggingResource)));
        }
    }
}
