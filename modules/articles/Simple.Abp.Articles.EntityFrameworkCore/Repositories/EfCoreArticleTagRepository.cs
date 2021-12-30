using Microsoft.EntityFrameworkCore;
using Simple.Abp.Articles.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.Repositories
{
    public class EfCoreArticleTagRepository : EfCoreRepository<ArticlesDbContext, ArticleTag, Guid>,IArticleTagRepository
    {
        public EfCoreArticleTagRepository(IDbContextProvider<ArticlesDbContext> 
            dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<bool> AnyByNameAsync(string name)
        {
            return DbSet.AnyAsync(c => c.Name == name);
        }
    }
}
