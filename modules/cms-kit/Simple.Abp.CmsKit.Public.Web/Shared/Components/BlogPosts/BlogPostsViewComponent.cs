using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.BlogPosts
{
    public class BlogPostsViewComponent: AbpViewComponent
    {

        public IViewComponentResult Invoke(string blogSlug, List<SimpleBlogPostDto> modelList)
        {
            return View("~/Shared/Components/BlogPosts/Default.cshtml", new { BlogSlug = blogSlug, BlogPosts = modelList });
        }
    }
}
