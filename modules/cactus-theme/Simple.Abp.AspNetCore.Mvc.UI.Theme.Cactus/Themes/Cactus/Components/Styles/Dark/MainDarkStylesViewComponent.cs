using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CactusTheme.Components.Styles.Dark
{
    public class MainDarkStylesViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Styles/Dark/Default.cshtml");
        }
    }
}
