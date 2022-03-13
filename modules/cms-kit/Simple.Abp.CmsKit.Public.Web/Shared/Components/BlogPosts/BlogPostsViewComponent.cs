using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.BlogPosts
{
    public class BlogPostsViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke(List<BlogPostPublicDto> modelList)
        {
            return View("~/Shared/Components/BlogPosts/Default.cshtml", modelList);
        }
    }
}
