using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.CactusTheme.Components.Menu
{
    public class MainMenuViewComponent : AbpViewComponent
    {
        private readonly IMenuManager _menuManager;
        public MainMenuViewComponent(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuManager.GetAsync(StandardMenus.Main);
            return View("~/Themes/Cactus/Components/Menu/Default.cshtml", menu);
        }
    }
}
