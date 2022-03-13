using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class DetailModel : AbpPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Month { get; set; }


        [BindProperty(SupportsGet = true)]
        public string Day { get; set; }


        [BindProperty(SupportsGet =true)]
        public string SEO { get; set; }

        //private readonly IArticleAppService _articleAppService;

        //public ArticleDto Article { get; set; }
        //public DetailModel(IArticleAppService articleAppService)
        //{
        //    _articleAppService = articleAppService;
        //}

        public virtual async Task<IActionResult> OnGetAsync()
        {
            //var path = $"/{Year}/{Month}/{Day}/{SEO}";
            //path = HttpUtility.UrlEncode(path);

            //Article = await _articleAppService.GetDefaultBySeoAsync(path);
            //if (Article == null)
            //    return NotFound();

            return Page();
        }
    }
}
