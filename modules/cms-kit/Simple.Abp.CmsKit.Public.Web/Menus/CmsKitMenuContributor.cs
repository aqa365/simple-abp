using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Simple.Abp.CactusTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.CmsKit.Menus;
using Volo.CmsKit.Public.Menus;

namespace Simple.Abp.CmsKit.Public.Web.Menu
{
    public class CmsKitMenuContributor : IMenuContributor
    {
        private IStringLocalizer l;
        private IMenuItemPublicAppService _menuItemPublicAppService;

        public CmsKitMenuContributor(ServiceConfigurationContext context)
        {
            _menuItemPublicAppService = context.Services.GetRequiredService<IMenuItemPublicAppService>();
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            l = context.GetLocalizer<CactusResource>();

            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }

            if (context.Menu.Name == CactusMenus.Footer)
            {
                await ConfigureFooterMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            context.Menu.Items.Add(new ApplicationMenuItem("Home", l["Menu:Home"], "/"));

            var menuItems = await _menuItemPublicAppService.GetListAsync();
            var subAppMenuItems = FindSubItems(null, menuItems);
            subAppMenuItems.ForEach(subAppMenuItem => context.Menu.Items.Add(subAppMenuItem));

            context.Menu.Items.Add(new ApplicationMenuItem("Tags", l["Menu:Tags"], "/tags"));
            context.Menu.Items.Add(new ApplicationMenuItem("About", l["Menu:About"], "/about"));
        }

        private Task ConfigureFooterMenuAsync(MenuConfigurationContext context)
        {

            context.Menu.Items.Insert(0, new ApplicationMenuItem("Home", l["Menu:Home"], "/", "fa fa-home"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blogs", l["Menu:Blogs"], "/blogs"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("About", l["Menu:About"], "/about"));

            return Task.CompletedTask;
        }


        private List<ApplicationMenuItem> FindSubItems(Guid? parentId, List<MenuItemDto> data)
        {
            List<ApplicationMenuItem> menuItems = new List<ApplicationMenuItem>();
           var items = data.Where(c => c.ParentId == parentId).ToList();
            if (items == null || items.Count <= 0)
                return menuItems;

            items.ForEach(subMenuItem =>
            {
                var subAppItem = new ApplicationMenuItem(subMenuItem.DisplayName,
                    l[$"Menu:{subMenuItem.DisplayName}"], $"/{subMenuItem.Url}", subMenuItem.Icon);
                var subAppMenuItems = FindSubItems(subMenuItem.Id, data);
                subAppMenuItems.ForEach(appMenuItem => subAppItem.Items.Add(appMenuItem));

                menuItems.Add(subAppItem);
            });

            return menuItems;
        }

    }
}
