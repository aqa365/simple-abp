using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Admin.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class BlogsModel : AbpPageModel
    {
        private readonly IBlogPublicAppService _blogPublicAppService;

        public List<BlogDto> Blogs { get; set; }

        public BlogsModel(IBlogPublicAppService blogPublicAppService)
        {
            _blogPublicAppService = blogPublicAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            PagedAndSortedResultRequestDto input = new PagedAndSortedResultRequestDto();
            Blogs = await _blogPublicAppService.GetAllAsync();
            return Page();
        }
    }
}
