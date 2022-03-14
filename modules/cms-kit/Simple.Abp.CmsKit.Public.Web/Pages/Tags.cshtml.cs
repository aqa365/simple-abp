using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class TagsModel : AbpPageModel
    {
        private readonly ISimpleTagPublicAppService _simpleTagPublicAppService;

        public List<TagDto> Tags { get; set; }

        public TagsModel(ISimpleTagPublicAppService simpleTagPublicAppService)
        {
            _simpleTagPublicAppService = simpleTagPublicAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            Tags = await _simpleTagPublicAppService.GetAllAsync();
            return Page();
        }

    }
}
