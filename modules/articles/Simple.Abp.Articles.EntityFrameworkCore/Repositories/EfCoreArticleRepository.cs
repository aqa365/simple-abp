using Microsoft.EntityFrameworkCore;
using Simple.Abp.Articles.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;

namespace Simple.Abp.Articles.Repositories
{
    public class EfCoreArticleRepository : EfCoreRepository<ArticlesDbContext, Article, Guid>,IArticleRepository
    {
        private readonly ICurrentUser _currentUser;
        public EfCoreArticleRepository(ICurrentUser currentUser,
            IDbContextProvider<ArticlesDbContext> dbContextProvider) : base(dbContextProvider)
        {
            _currentUser = currentUser;
        }

        public override IQueryable<Article> WithDetails()
        {
            return GetQueryable().Include(x => x.Catalog);
        }

        public IQueryable<Article> WithDefaultFilter(IQueryable<Article> query = null)
        {
            var userId = _currentUser.Id;

            //query = query ?? this;

            if (userId == null)
            {
                return query.Where(c => c.State == EnumArticleState.Default);
            }

            return query.Where(c => c.State == EnumArticleState.Default
                                || (c.State == EnumArticleState.Private && c.CreatorId == userId));
        }

        public IQueryable<Article> WithDefaultFilterDetails()
        {
            return WithDefaultFilter(
                 WithDetails()
            );
        }
    }
}
