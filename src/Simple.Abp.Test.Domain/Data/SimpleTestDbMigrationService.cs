using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Simple.Abp.Test
{
    public class SimpleTestDbMigrationService : ITransientDependency
    {
        public ILogger<SimpleTestDbMigrationService> Logger { get; set; }

        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<ISimpleTestDbSchemaMigrator> _dbSchemaMigrators;
        private readonly ICurrentTenant _currentTenant;

        public SimpleTestDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<ISimpleTestDbSchemaMigrator> dbSchemaMigrators,
            ICurrentTenant currentTenant)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
            _currentTenant = currentTenant;

            Logger = NullLogger<SimpleTestDbMigrationService>.Instance;
        }

        public async Task MigrateAsync()
        {
            Logger.LogInformation("Started database migrations...");

            await MigrateDatabaseSchemaAsync();
            await SeedDataAsync();

            Logger.LogInformation($"Successfully completed host database migrations.");

            //var tenants = await _tenantRepository.GetListAsync(includeDetails: true);

            //var migratedDatabaseSchemas = new HashSet<string>();
            //foreach (var tenant in tenants)
            //{
            //    if (!tenant.ConnectionStrings.Any())
            //    {
            //        continue;
            //    }

            //    using (_currentTenant.Change(tenant.Id))
            //    {
            //        var tenantConnectionStrings = tenant.ConnectionStrings
            //            .Select(x => x.Value)
            //            .ToList();

            //        if (!migratedDatabaseSchemas.IsSupersetOf(tenantConnectionStrings))
            //        {
            //            await MigrateDatabaseSchemaAsync(tenant);

            //            migratedDatabaseSchemas.AddIfNotContains(tenantConnectionStrings);
            //        }

            //        await SeedDataAsync(tenant);
            //    }

            //    Logger.LogInformation($"Successfully completed {tenant.Name} tenant database migrations.");
            //}

            //Logger.LogInformation("Successfully completed database migrations.");
        }

        private async Task MigrateDatabaseSchemaAsync()
        {
            Logger.LogInformation(
                $"Migrating schema database...");

            foreach (var migrator in _dbSchemaMigrators)
                await migrator.MigrateAsync();
        }

        private async Task SeedDataAsync()
        {
            Logger.LogInformation($"Executing database seed...");
            await _dataSeeder.SeedAsync(new DataSeedContext()
                    .WithProperty("AdminEmail", "aqa.china@outlook.com")
                    .WithProperty("AdminPassword", "Aa115869_ka"));
        }
    }
}
