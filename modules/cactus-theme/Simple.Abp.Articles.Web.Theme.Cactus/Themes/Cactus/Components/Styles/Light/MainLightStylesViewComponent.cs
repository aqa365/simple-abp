using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CactusTheme.Components.Styles.Light
{
    public class MainLightStylesViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Styles/Light/Default.cshtml");
        }
    }
}
