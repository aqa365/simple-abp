using Simple.Abp.Articles.EntityFrameworkCore;
using Simple.Abp.Articles.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simple.Abp.Articles.Repositories
{
    public class EfCoreArticleCatalogRepository : EfCoreRepository<ArticlesDbContext, ArticleCatalog, Guid>, IArticleCatalogRepository
    {
        public EfCoreArticleCatalogRepository(IDbContextProvider<ArticlesDbContext> 
            dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
