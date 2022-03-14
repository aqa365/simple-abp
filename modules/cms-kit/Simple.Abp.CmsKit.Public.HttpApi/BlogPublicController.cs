using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.Admin;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.GlobalFeatures;

namespace Simple.Abp.CmsKit.Public
{
    [RequiresGlobalFeature(typeof(BlogsFeature))]
    [RemoteService(Name = CmsKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms-kit-public")]
    [Route("api/cms-kit-public/blogs")]
    public class BlogPublicController : SimpleCmsKitPublicControllerBase, IBlogPublicAppService
    {
        private IBlogPublicAppService _blogPublicAppService;
        public BlogPublicController(IBlogPublicAppService blogPublicAppService)
        {
            _blogPublicAppService = blogPublicAppService;
        }

        [HttpGet]
        public Task<List<BlogDto>> GetAllAsync()
        {
            return _blogPublicAppService.GetAllAsync();
        }
    }
}
