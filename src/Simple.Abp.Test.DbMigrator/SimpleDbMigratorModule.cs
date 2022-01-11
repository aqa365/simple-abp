using Simple.Abp.Test.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Simple.Abp.Test.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SimpleTestEntityFrameworkCoreModule),
        typeof(SimpleTestApplicationContractsModule)
        )]
    public class SimpleTestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}