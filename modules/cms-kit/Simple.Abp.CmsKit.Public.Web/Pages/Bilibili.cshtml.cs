using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simple.Abp.CmsKit.Public.Web.Shared.Components.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Pages
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
        public List<BlogPostPublicDto> Videos { get; set; }

        private readonly IBlogPostPublicAppService _blogPostPublicAppService;

        public BilibiliModel(IBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
            Videos = new List<BlogPostPublicDto>();
        }
        public virtual async Task<IActionResult> OnGetAsync()
        {
            PagedAndSortedResultRequestDto request = new PagedAndSortedResultRequestDto();
            var pageResult = await _blogPostPublicAppService.GetListAsync("bilibili", request);
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
