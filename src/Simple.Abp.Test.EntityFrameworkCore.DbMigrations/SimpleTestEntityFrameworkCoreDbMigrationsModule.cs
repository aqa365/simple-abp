using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.Test.EntityFrameworkCore
{
    [DependsOn(
       typeof(SimpleTestEntityFrameworkCoreModule)
    )]
    public class SimpleTestEntityFrameworkCoreDbMigrationsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SimpleTestMigrationsDbContext>();
        }
    }
}
