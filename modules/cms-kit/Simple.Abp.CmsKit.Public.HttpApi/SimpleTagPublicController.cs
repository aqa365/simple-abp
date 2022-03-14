using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.GlobalFeatures;
using Volo.CmsKit.Admin;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public
{
    [RequiresGlobalFeature(typeof(TagsFeature))]
    [RemoteService(Name = CmsKitAdminRemoteServiceConsts.RemoteServiceName)]
    [Area("cms-kit-public")]
    [ControllerName("TagPublic")]
    [Route("api/cms-kit-public/tags")]
    public class SimpleTagPublicController : SimpleCmsKitPublicControllerBase, ISimpleTagPublicAppService
    {
        private ISimpleTagPublicAppService _simpleTagPublicAppService;
        public SimpleTagPublicController(ISimpleTagPublicAppService simpleTagPublicAppService)
        {
            _simpleTagPublicAppService = simpleTagPublicAppService;
        }

        [HttpGet("all")]
        public Task<List<TagDto>> GetAllAsync()
        {
          return _simpleTagPublicAppService.GetAllAsync();
        }
    }
}
