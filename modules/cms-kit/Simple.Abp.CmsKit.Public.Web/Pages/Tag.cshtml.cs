using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simple.Abp.CmsKit.Public.Dtos;
using Simple.Abp.CmsKit.Public.Web.Shared.Components.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class TagModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string TagName { get; set; }

        public Dictionary<int, List<SimpleBlogPostDto>> BlogPosts { get; set; }

        public PaginationViewModel PaginationViewModel { get; set; }

        private readonly ISimpleBlogPostPublicAppService _blogPostPublicAppService;

        public TagModel(ISimpleBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPostPublicAppService = blogPostPublicAppService;
            BlogPosts = new Dictionary<int, List<SimpleBlogPostDto>>();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            SimpleBlogPostGetListInput input = new SimpleBlogPostGetListInput();
            input.SkipCount = (PageIndex - 1) * input.MaxResultCount;

            var pageResult = await _blogPostPublicAppService.GetListByTagAsync(TagName, input);
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

            string urlTemplate = $"/tags/{TagName}/page/{{pageindex}}";
            PaginationViewModel = new PaginationViewModel(PageIndex,
                input.MaxResultCount, pageResult.TotalCount, urlTemplate);

            return Page();
        }
    }
}
