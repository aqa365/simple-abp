using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.Articles.Web.Theme.Cactus.Components.Scripts
{
    public class MainScriptsViewComponent : AbpViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Themes/Cactus/Components/Scripts/Default.cshtml");
        }
    }
}
