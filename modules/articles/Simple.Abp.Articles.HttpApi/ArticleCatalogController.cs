using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("ArticlesArticle")]
    [ControllerName("ArticleCatalog")]
    [Route("api/article-catalog")]
    public class ArticleCatalogController : ArticlesController, IArticleCatalogAppService
    {
        private readonly IArticleCatalogAppService _catalogAppService;
        public ArticleCatalogController(IArticleCatalogAppService catalogAppService)
        {
            _catalogAppService = catalogAppService;
        }

        [HttpPost]
        public Task<ArticleCatalogDto> CreateAsync(CreateUpdateArticleCatalogDto input)
        {
            return _catalogAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _catalogAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleCatalogDto> GetAsync(Guid id)
        {
            return _catalogAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("exist-article")]
        public Task<List<ArticleCatalogDto>> GetExistArticleList()
        {
            return _catalogAppService.GetExistArticleList();
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleCatalogDto>> GetListAsync(ArticlePagedCatalogRequestDto input)
        {
            return _catalogAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("trees")]
        public Task<List<ArticleCatalogDto>> GetTreesAsync()
        {
            return _catalogAppService.GetTreesAsync();
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleCatalogDto> UpdateAsync(Guid id, CreateUpdateArticleCatalogDto input)
        {
            return _catalogAppService.UpdateAsync(id, input);
        }
    }
}
