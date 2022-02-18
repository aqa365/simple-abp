using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles.Web.Theme.Cactus.Components.Header
{
    public class MainHeaderViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Header/Default.cshtml");
        }
    }
}
