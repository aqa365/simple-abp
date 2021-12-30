using Simple.Abp.Articles.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simple.Abp.Articles
{
    public interface IArticleAppService :
        ICrudAppService< 
            ArticleDto, 
            Guid,
            ArticlePagedRequestDto,
            CreateUpdateArticleDto,
            CreateUpdateArticleDto>
    {
        Task<ArticleDto> GetDefaultAsync(Guid id);

        Task<ArticleDto> GetDefaultBySeoAsync(string seoPath);

        Task<PagedResultDto<ArticleDto>> GetDefaultListAsync(ArticlePagedRequestDto request);
    }
}