using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Public;

namespace Simple.Abp.CmsKit.Public
{
    [RequiresGlobalFeature(typeof(BlogsFeature))]
    [RemoteService(Name = CmsKitPublicRemoteServiceConsts.RemoteServiceName)]
    [Area(CmsKitPublicRemoteServiceConsts.ModuleName)]
    [ControllerName("BlogPostPublic")]
    [Route("api/cms-kit-public/blog-posts")]
    public class SimpleBlogPostPublicController : SimpleCmsKitPublicControllerBase, ISimpleBlogPostPublicAppService
    {
        protected ISimpleBlogPostPublicAppService _blogPostPublicController { get; }
        public SimpleBlogPostPublicController(ISimpleBlogPostPublicAppService blogPostPublicController)
        {
            _blogPostPublicController = blogPostPublicController;
        }

        [HttpGet]
        [Route("with-detail/{blogSlug}/{blogPostSlug}")]
        public Task<SimpleBlogPostDto> GetAsync(string blogSlug, string blogPostSlug)
        {
            return _blogPostPublicController.GetAsync(blogSlug, blogPostSlug);
        }

        [HttpGet]
        [Route("with-query/{blogSlug}")]
        public Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input)
        {
           return _blogPostPublicController.GetListAsync(blogSlug, input);
        }
    }
}
