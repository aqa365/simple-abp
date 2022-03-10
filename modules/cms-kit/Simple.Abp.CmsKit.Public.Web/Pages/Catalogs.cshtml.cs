using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Public.Web.Pages
{
    public class CatalogsModel : AbpPageModel
    {
        private readonly IArticleCatalogAppService _articleCatalogAppService;

        public List<ArticleCatalogDto> Catalogs { get; set; }

        public CatalogsModel(IArticleCatalogAppService catalogAppService)
        {
            _articleCatalogAppService = catalogAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Catalogs = await _articleCatalogAppService.GetExistArticleList();
            return Page();
        }
    }
}
