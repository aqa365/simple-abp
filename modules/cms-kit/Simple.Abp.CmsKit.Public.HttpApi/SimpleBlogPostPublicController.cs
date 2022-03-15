using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Public;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    [RequiresGlobalFeature(typeof(BlogsFeature))]
    [RemoteService(Name = CmsKitPublicRemoteServiceConsts.RemoteServiceName)]
    [Area(CmsKitPublicRemoteServiceConsts.ModuleName)]
    [ControllerName("BlogPostPublic")]
    [Route("api/cms-kit-public/blog-posts")]
    public class SimpleBlogPostPublicController : SimpleCmsKitPublicControllerBase, ISimpleBlogPostPublicAppService
    {
        protected ISimpleBlogPostPublicAppService _blogPostPublicAppService { get; }
        public SimpleBlogPostPublicController(ISimpleBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
        }

        [HttpGet]
        [Route("previous/{blogId}/{blogPostId}")]
        public Task<BlogPostPublicDto> GetPreviousAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
            return _blogPostPublicAppService.GetPreviousAsync(blogId, blogPostId, creationTime);
        }

        [HttpGet]
        [Route("next/{blogId}/{blogPostId}")]
        public Task<BlogPostPublicDto> GetNextAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
           return _blogPostPublicAppService.GetNextAsync(blogId, blogPostId,creationTime);
        }

        [HttpGet]
        [Route("with-detail/{blogSlug}/{blogPostSlug}")]
        public Task<SimpleBlogPostDto> GetAsync(string blogSlug, string blogPostSlug)
        {
            return _blogPostPublicAppService.GetAsync(blogSlug, blogPostSlug);
        }

        [HttpGet]
        [Route("with-query/{blogSlug}")]
        public Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input)
        {
           return _blogPostPublicAppService.GetListAsync(blogSlug, input);
        }
    }
}
