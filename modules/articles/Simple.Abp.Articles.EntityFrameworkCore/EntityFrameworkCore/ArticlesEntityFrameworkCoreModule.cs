using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.Articles.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    [DependsOn(
       typeof(AbpArticlesDomainModule),
       typeof(AbpEntityFrameworkCoreModule)
    )]
    public class ArticlesEntityFrameworkCoreModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ArticlesDbContext>(options =>
            {
                options.AddRepository<Article, EfCoreArticleRepository>();
                options.AddRepository<ArticleCatalog, EfCoreArticleCatalogRepository>();
                options.AddRepository<ArticleTag, EfCoreArticleTagRepository>();
            });
        }
    }
}
