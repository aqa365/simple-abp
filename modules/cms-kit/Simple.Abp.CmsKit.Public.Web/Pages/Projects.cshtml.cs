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
    public class ProjectsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        /// <summary>
        /// projects
        /// </summary>
        public List<ArticleDto> Projects { get; set; }

        private readonly IArticleAppService _articleAppService;

        public ProjectsModel(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
            Projects = new List<ArticleDto>();
        }
        public virtual async Task<IActionResult> OnGetAsync()
        {
            ArticlePagedRequestDto request = new ArticlePagedRequestDto();
            request.PageIndex = PageIndex;
            request.Filter = Filter;
            request.CatalogTitle = "projects";

            var pageResult = await _articleAppService.GetDefaultListAsync(request);
            if (pageResult == null)
                return Page();

            Projects = pageResult.Items.ToList();

            string urlTemplate = "/projects/page/{pageindex}";
            if (!Filter.IsNullOrWhiteSpace())
                urlTemplate += $"?filter={Filter}";

            PaginationViewModel = new PaginationViewModel(PageIndex,
                request.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
