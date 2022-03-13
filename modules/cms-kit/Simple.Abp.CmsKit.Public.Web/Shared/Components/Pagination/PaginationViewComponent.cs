using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.Pagination
{
    public class PaginationViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke(PaginationViewModel vm)
        {
            return View("~/Shared/Components/Pagination/Default.cshtml", vm);
        }
    }
}
