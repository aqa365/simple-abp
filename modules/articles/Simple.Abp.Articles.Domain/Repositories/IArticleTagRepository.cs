using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles.Repositories
{
    public interface IArticleTagRepository: IRepository<ArticleTag, Guid>
    {
        Task<bool> AnyByNameAsync(string name);
    }
}
