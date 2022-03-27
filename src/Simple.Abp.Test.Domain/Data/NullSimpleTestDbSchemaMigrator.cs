using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Test
{
    /* This is used if database provider does't define
     * IBlogDbSchemaMigrator implementation.
     */
    public class NullSimpleTestDbSchemaMigrator : ISimpleTestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}