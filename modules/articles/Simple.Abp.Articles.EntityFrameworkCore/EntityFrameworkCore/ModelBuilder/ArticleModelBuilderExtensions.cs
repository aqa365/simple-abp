using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Articles
{
    public static class ArticleModelBuilderExtensions
    {
        public static void BuilderArticle(this ModelBuilder builder, 
            AbpModelBuilderConfigurationOptions options)
        {
            builder.Entity<Article>(b =>
            {
                b.ToTable(options.TablePrefix + "Articles", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.CatalogId).IsRequired();

                b.Property(a => a.SEOPath)
                      .HasMaxLength(ArticleConsts.MaxSEOPathLength);

                b.Property(a => a.Title).IsRequired()
                    .HasMaxLength(ArticleConsts.MaxTitleLength);

                b.Property(a => a.Content).IsRequired();

                b.Property(a => a.IsRefinement).HasDefaultValue(false);
                b.Property(a => a.IsTop).HasDefaultValue(false);
                b.Property(a => a.Order).HasDefaultValue(0);
                b.Property(a => a.State).HasDefaultValue(EnumArticleState.Default);
                b.Property(a => a.Summary).HasMaxLength(ArticleConsts.MaxSummaryLength);
                b.Property(a => a.Tag).HasMaxLength(ArticleTagConsts.MaxNameLength);
            });
        }
    }
}
