using Microsoft.Extensions.Configuration;
using Simple.Abp.CactusTheme;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Simple.Abp.Articles.Public.Web.Menus
{
    public class ArticlesMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public ArticlesMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }

            if (context.Menu.Name == CactusMenus.Footer)
            {
                await ConfigureFooterMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {

            var l = context.GetLocalizer<CactusResource>();

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Home", l["Menu:Home"], "/"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Writing", l["Menu:Writing"], "/writing"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Catalogs", l["Menu:Catalogs"], "/catalogs"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Tags", l["Menu:Tags"], "/tags"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Bilibili", l["Menu:Bilibili"], "/bilibili"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Projects", l["Menu:Projects"], "/projects"));

            return Task.CompletedTask;
        }

        private Task ConfigureFooterMenuAsync(MenuConfigurationContext context)
        {

            var l = context.GetLocalizer<CactusResource>();
            context.Menu.Items.Insert(0, new ApplicationMenuItem("Blog.Home", l["Menu:Home"], "/", "fa fa-home"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.Writing", l["Menu:Writing"], "/writing"));

            context.Menu.Items.Add(
                new ApplicationMenuItem("Blog.About", l["Menu:About"], "/about"));

            return Task.CompletedTask;
        }
    }
}
