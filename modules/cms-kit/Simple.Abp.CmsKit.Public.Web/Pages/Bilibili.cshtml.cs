using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simple.Abp.Articles.Dtos;
using Simple.Abp.Articles.Public.Web.Shared.Components.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Abp.Articles.Public.Web.Pages
{
    public class BilibiliModel : PageModel
    {
        
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        /// <summary>
        /// bilibili
        /// </summary>
        public List<ArticleDto> Videos { get; set; }

        private readonly IArticleAppService _articleAppService;

        public BilibiliModel(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
            Videos = new List<ArticleDto>();
        }
        public virtual async Task<IActionResult> OnGetAsync()
        {
            ArticlePagedRequestDto request = new ArticlePagedRequestDto();
            request.PageIndex = PageIndex;
            request.Filter = Filter;
            request.CatalogTitle = "bilibili";

            var pageResult = await _articleAppService.GetDefaultListAsync(request);
            if (pageResult == null)
                return Page();

            Videos = pageResult.Items.ToList();

            string urlTemplate = "/bilibili/page/{pageindex}";
            if (!Filter.IsNullOrWhiteSpace())
                urlTemplate += $"?filter={Filter}";

            PaginationViewModel = new PaginationViewModel(PageIndex,
                request.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
