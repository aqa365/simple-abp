using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles
{
    [RemoteService]
    [Area("Articles")]
    [ControllerName("ArticleTag")]
    [Route("api/articles/tag")]
    public class AricleTagController : ArticlesController, IArticleTagAppService
    {

        private readonly IArticleTagAppService _tagAppService;
        public AricleTagController(IArticleTagAppService tagAppService)
        {
            _tagAppService = tagAppService;
        }

        [HttpPost]
        public Task<ArticleTagDto> CreateAsync(CreateUpdateArticleTagDto input)
        {
            return _tagAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _tagAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<List<ArticleTagDto>> GetAllAsync()
        {
            return _tagAppService.GetAllAsync();
        }

        [HttpGet]
        [Route("exist-article")]
        public Task<List<ArticleTagDto>> GetExistArticleList()
        {
            return _tagAppService.GetExistArticleList();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ArticleTagDto> GetAsync(Guid id)
        {
            return _tagAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ArticleTagDto>> GetListAsync(ArticlePagedTagRequestDto input)
        {
            return _tagAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ArticleTagDto> UpdateAsync(Guid id, CreateUpdateArticleTagDto input)
        {
            return _tagAppService.UpdateAsync(id, input);
        }
    }
}
