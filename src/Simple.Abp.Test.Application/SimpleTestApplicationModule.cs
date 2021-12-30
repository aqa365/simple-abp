using Simple.Abp.Account;
using Simple.Abp.AuditLogging;
using Simple.Abp.Identity;
using Simple.Abp.IdentityServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Simple.Abp.Test
{
    [DependsOn(
        typeof(SimpleTestDomainModule),
        typeof(SimpleTestApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityServerApplicationModule),
        typeof(AbpAuditLoggingApplicationModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule)
    )]
    public class SimpleTestApplicationModule:AbpModule
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
