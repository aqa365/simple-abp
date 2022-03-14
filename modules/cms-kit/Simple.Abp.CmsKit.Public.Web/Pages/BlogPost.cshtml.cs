using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class BlogPostModel : AbpPageModel
    {

        [BindProperty(SupportsGet = true)]
        public string BlogSlug { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BlogPostSlug { get; set; }

        public SimpleBlogPostDto BlogPost { get; set; }

        private readonly ISimpleBlogPostPublicAppService _blogPostPublicAppService;

        public BlogPostModel(ISimpleBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            BlogPost = await _blogPostPublicAppService.GetAsync(BlogSlug, BlogPostSlug);
            if (BlogPost == null)
                return NotFound();

            return Page();
        }
    }
}
