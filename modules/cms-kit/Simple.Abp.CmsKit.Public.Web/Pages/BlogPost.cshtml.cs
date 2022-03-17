using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class BlogPostModel : AbpPageModel
    {

        [BindProperty(SupportsGet = true)]
        public string BlogSlug { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BlogPostSlug { get; set; }

        public SimpleBlogPostDto BlogPost { get; set; }

        public List<TagDto> Tags { get; set; }

        private readonly ISimpleBlogPostPublicAppService _blogPostPublicAppService;

        private readonly ITagAppService _tagAppService;

        public BlogPostModel(ISimpleBlogPostPublicAppService blogPostPublicAppService, ITagAppService tagAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
            _tagAppService = tagAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            BlogPost = await _blogPostPublicAppService.GetAsync(BlogSlug, BlogPostSlug);
            if (BlogPost == null)
                return NotFound();

            Tags = await _tagAppService.GetAllRelatedTagsAsync("BlogPost", BlogPost.Id.ToString())
                ?? new List<TagDto>();
            return Page();
        }
    }
}
