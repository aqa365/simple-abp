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
        /// ��ȡ����б�(Tree)
        /// </summary>
        /// <returns></returns>
        Task<List<ArticleCatalogDto>> GetTreesAsync();

        /// <summary>
        /// ��ȡ�������µ����
        /// </summary>
        /// <returns></returns>
        Task<List<ArticleCatalogDto>> GetExistArticleList();
    }
}