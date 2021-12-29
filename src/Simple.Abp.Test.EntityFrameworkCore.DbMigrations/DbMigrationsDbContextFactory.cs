using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Simple.Abp.Test.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class DbMigrationsDbContextFactory : IDesignTimeDbContextFactory<SimpleTestMigrationsDbContext>
    {
        public SimpleTestMigrationsDbContext CreateDbContext(string[] args)
        {
            //KAEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SimpleTestMigrationsDbContext>()
                .UseMySql(
                    configuration.GetConnectionString("Default"), 
                    new MySqlServerVersion(new Version(8, 0, 16))
                );

            return new SimpleTestMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Simple.Abp.Test.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
