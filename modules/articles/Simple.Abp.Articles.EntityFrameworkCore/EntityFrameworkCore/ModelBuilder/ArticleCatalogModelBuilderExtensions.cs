using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Articles
{
    public static class ArticleCatalogModelBuilderExtensions
    {
        public static void BuilderArticleCatalog(this ModelBuilder builder,
          AbpModelBuilderConfigurationOptions options)
        {
            builder.Entity<ArticleCatalog>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleCatalogs", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.Title).IsRequired()
                    .HasMaxLength(ArticleCatalogConsts.MaxTitleLength);

                b.Property(a => a.Description)
                   .HasMaxLength(ArticleCatalogConsts.MaxDescriptionLength);
            });
        }
    }
}
