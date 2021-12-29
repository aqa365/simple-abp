using System.Threading.Tasks;

namespace Simple.Abp.Test
{
    public interface ISimpleTestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
