using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using Volo.CmsKit.Admin.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.Project
{
    public class ProjectViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(List<BlogPostDto> modelList)
        {
            return View("~/Shared/Components/Project/Default.cshtml", modelList);
        }
    }
}
