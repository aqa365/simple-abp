using Microsoft.EntityFrameworkCore;
using Simple.Abp.Articles.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace Simple.Abp.Test.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See BlogDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class SimpleTestMigrationsDbContext : AbpDbContext<SimpleTestMigrationsDbContext>
    {
        public SimpleTestMigrationsDbContext(DbContextOptions<SimpleTestMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureSettingManagement();
            builder.ConfigureIdentityServer();
            builder.ConfigureArticles();

            /* Configure your own tables/entities inside the ConfigureBlog method */
            builder.ConfigureSimpleTest();
        }
    }
}