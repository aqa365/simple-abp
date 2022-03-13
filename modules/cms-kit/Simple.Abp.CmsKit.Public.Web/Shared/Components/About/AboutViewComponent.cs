using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.About
{
    public class AboutViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Shared/Components/About/Default.cshtml");
        }
    }
}
