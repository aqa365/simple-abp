using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public static class ArticlesDbContextModelBuilderExtensions
    {
        public static void ConfigureArticles(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] Action<ArticlesModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ArticlesModelBuilderConfigurationOptions(
                ArticlesConsts.DbTablePrefix,
                ArticlesConsts.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.BuilderArticle(options);
            builder.BuilderArticleCatalog(options);
            builder.BuilderArticleTag(options);
        }
    }
}
