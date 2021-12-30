using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles.Repositories
{
    public interface IArticleRepository: IRepository<Article, Guid>
    {
        IQueryable<Article> WithDefaultFilterDetails();

        IQueryable<Article> WithDefaultFilter(IQueryable<Article> query = null);
    }
}
