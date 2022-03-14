using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CactusTheme.Components.Header
{
    public class MainHeaderViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Header/Default.cshtml");
        }
    }
}
