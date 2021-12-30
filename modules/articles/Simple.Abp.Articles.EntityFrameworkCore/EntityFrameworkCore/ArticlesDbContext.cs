using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See BlogMigrationsDbContext for migrations.
     */
    [ConnectionStringName("AbpArticles")]
    public class ArticlesDbContext : AbpDbContext<ArticlesDbContext>
    {
        //public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside BlogDbContextModelCreatingExtensions.ConfigureBlog
         */
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCatalog> ArticleCatalogs { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureArticles();
        }
    }
}
