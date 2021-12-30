using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Articles
{
    public static class ArticleTagModelBuilderExtensions
    {
        public static void BuilderArticleTag(this ModelBuilder builder,
            AbpModelBuilderConfigurationOptions options)
        {
            builder.Entity<ArticleTag>(b =>
            {
                b.ToTable(options.TablePrefix + "ArticleTags", options.Schema);

                b.ConfigureByConvention();

                b.Property(a => a.Name).IsRequired()
                    .HasMaxLength(ArticleTagConsts.MaxNameLength);
            });
        }
    }
}
