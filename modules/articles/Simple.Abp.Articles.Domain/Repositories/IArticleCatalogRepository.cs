using System;
using Volo.Abp.Domain.Repositories;

namespace Simple.Abp.Articles.Repositories
{
    public interface IArticleCatalogRepository : IRepository<ArticleCatalog, Guid>
    {
    }
}
