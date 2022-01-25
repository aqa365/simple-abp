using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System.Web;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("Articles")]
    [ControllerName("Article")]
    [Route("api/articles/article")]
    public class ArticleController : ArticlesController, IArticleAppService
    {
        private readonly IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        [HttpPost]
        public Task<ArticleDto> CreateAsync(CreateUpdateArticleDto input)
        {
            return _articleAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _articleAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public Task<ArticleDto> GetAsync(Guid id)
        {
            return _articleAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleDto>> GetListAsync(ArticlePagedRequestDto input)
        {
            return _articleAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("default/{id}")]
        public Task<ArticleDto> GetDefaultAsync(Guid id)
        {
            return _articleAppService.GetDefaultAsync(id);
        }

        [HttpGet]
        [Route("default-by-seo/{seoPath}")]
        public Task<ArticleDto> GetDefaultBySeoAsync(string seoPath)
        {
            if (!seoPath.IsNullOrWhiteSpace())
                seoPath = HttpUtility.UrlDecode(seoPath);

            return _articleAppService.GetDefaultBySeoAsync(seoPath);
        }

        [HttpGet]
        [Route("default")]
        public Task<PagedResultDto<ArticleDto>> GetDefaultListAsync(ArticlePagedRequestDto request)
        {
            return _articleAppService.GetDefaultListAsync(request);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleDto> UpdateAsync(Guid id, CreateUpdateArticleDto input)
        {
            return _articleAppService.UpdateAsync(id, input);
        }
    }
}
