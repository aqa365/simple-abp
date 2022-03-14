using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Web.Shared.Components.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class BlogModel : AbpPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string BlogSlug { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }


        public Dictionary<int, List<BlogPostPublicDto>> BlogPosts { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }


        private readonly IBlogPostPublicAppService _blogPostPublicAppService;

        public BlogModel(IBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
            BlogPosts = new Dictionary<int, List<BlogPostPublicDto>>();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            PagedAndSortedResultRequestDto input =new PagedAndSortedResultRequestDto();
            input.SkipCount = (PageIndex - 1) * input.MaxResultCount;

            var pageResult = await _blogPostPublicAppService.GetListAsync(BlogSlug, input);
            if (pageResult == null)
                return Page();

            // 根据年份分组
            var years = pageResult.Items.Select(c => c.CreationTime.Year).GroupBy(c => c);
            foreach (var group in years)
            {
                var year = group.Key;
                var items = pageResult.Items.Where(c => c.CreationTime.Year == year).ToList();
                BlogPosts.Add(year, items);
            }

            string urlTemplate = $"/blogs/{BlogSlug}/page/{{pageindex}}";
            if (!Filter.IsNullOrWhiteSpace())
                urlTemplate += $"?filter={Filter}";

            PaginationViewModel = new PaginationViewModel(PageIndex,
                input.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
