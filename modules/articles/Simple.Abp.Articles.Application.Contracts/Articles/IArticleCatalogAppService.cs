using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public interface IArticleCatalogAppService :
        ICrudAppService< 
            ArticleCatalogDto, 
            Guid,
            ArticlePagedCatalogRequestDto,
            CreateUpdateArticleCatalogDto,
            CreateUpdateArticleCatalogDto>
    {
        /// <summary>
        /// 获取类别列表(Tree)
        /// </summary>
        /// <returns></returns>
        Task<List<ArticleCatalogDto>> GetTreesAsync();

        /// <summary>
        /// 获取存在文章的类别
        /// </summary>
        /// <returns></returns>
        Task<List<ArticleCatalogDto>> GetExistArticleList();
    }
}