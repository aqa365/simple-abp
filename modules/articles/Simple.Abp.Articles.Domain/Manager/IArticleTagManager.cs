using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Simple.Abp.Articles.Manager
{
    public interface IArticleTagManager:IDomainService
    {
        Task<ArticleTag> CreateAsync(string name);
    }
}
