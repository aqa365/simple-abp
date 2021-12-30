using Simple.Abp.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public interface IArticleTagAppService :
        ICrudAppService<
            ArticleTagDto, 
            Guid,
            ArticlePagedTagRequestDto,
            CreateUpdateArticleTagDto,
            CreateUpdateArticleTagDto>
    {
        Task<List<ArticleTagDto>> GetAllAsync();

        /// <summary>
        /// 获取存在文章的Tag
        /// </summary>
        /// <returns></returns>
        Task<List<ArticleTagDto>> GetExistArticleList();
    }
}