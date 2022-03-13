using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class TagsModel : AbpPageModel
    {
        //private readonly IArticleTagAppService _articleTagAppService;

        //public List<ArticleTagDto> Tags { get; set; }

        //public TagsModel(IArticleTagAppService tagAppService)
        //{
        //    _articleTagAppService = tagAppService;
        //}

        public virtual async Task<IActionResult> OnGetAsync()
        {
            //Tags = await _articleTagAppService.GetExistArticleList();
            return Page();
        }

    }
}
