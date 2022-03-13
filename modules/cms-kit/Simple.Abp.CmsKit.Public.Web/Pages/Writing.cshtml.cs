using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class WritingModel : AbpPageModel
    {

        //[BindProperty(SupportsGet = true)]
        //public int PageIndex { get; set; } = 1;

        //[BindProperty(SupportsGet = true)]
        //public string Filter { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string CatalogTitle { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public string TagName { get; set; }

        //public Dictionary<int, List<ArticleDto>> Articles { get; set; }

        //public PaginationViewModel PaginationViewModel { get; set; }


        //private readonly IArticleAppService _articleAppService;

        //public WritingModel(IArticleAppService articleAppService)
        //{
        //    _articleAppService = articleAppService;
        //    Articles = new Dictionary<int, List<ArticleDto>>();
        //}

        public virtual async Task<IActionResult> OnGetAsync()
        {
            //ArticlePagedRequestDto request = new ArticlePagedRequestDto();
            //request.PageIndex = PageIndex;
            //request.Filter = Filter;
            //request.CatalogTitle = CatalogTitle;
            //request.TagName = TagName;

            //var pageResult = await _articleAppService.GetDefaultListAsync(request);
            //if (pageResult == null)
            //    return Page();

            //// 根据年份分组
            //var years = pageResult.Items.Select(c => c.CreationTime.Year).GroupBy(c => c);
            //foreach (var group in years)
            //{
            //    var year = group.Key;
            //    var items = pageResult.Items.Where(c => c.CreationTime.Year == year).ToList();
            //    Articles.Add(year, items);
            //}

            //string urlTemplate = "/writing/page/{pageindex}";
            //if (!CatalogTitle.IsNullOrWhiteSpace())
            //    urlTemplate = $"/writing/catalog/{CatalogTitle}/page/{{pageindex}}";
            //if(!TagName.IsNullOrWhiteSpace())
            //    urlTemplate = $"/writing/tag/{TagName}/page/{{pageindex}}";

            //if (!Filter.IsNullOrWhiteSpace())
            //    urlTemplate += $"?filter={Filter}";

            //PaginationViewModel = new PaginationViewModel(PageIndex,
            //    request.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
