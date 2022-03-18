using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Public.Pages;

namespace Simple.Abp.CmsKit.Public.Web.Pages.CmsKitPages
{
    public class IndexModel : AbpPageModel
    {
        private readonly IPagePublicAppService _pagePublicAppService;

        [BindProperty(SupportsGet = true)]
        public string Slug { get; set; }

        public PageDto PageModel { get; set; }

        public IndexModel(IPagePublicAppService pagePublicAppService)
        {
            _pagePublicAppService = pagePublicAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            PageModel = await _pagePublicAppService.FindBySlugAsync(Slug);
            if (PageModel == null)
                return NotFound();

            return Page();
        }
    }
}
