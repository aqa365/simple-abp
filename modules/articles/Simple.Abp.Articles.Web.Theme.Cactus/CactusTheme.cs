using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Articles.Web.Theme.Cactus
{
    [ThemeName(Name)]
    public class CactusTheme : ITransientDependency, ITheme
    {
        public const string Name = "Cactus";
        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Application:
                    return "~/Themes/Cactus/Layouts/Application.cshtml";
                case "Application2":
                    return "~/Themes/Cactus/Layouts/Application2.cshtml";
                case StandardLayouts.Account:
                    return "~/Themes/Cactus/Layouts/Account.cshtml";
                default:
                    return fallbackToDefault ? "~/Themes/Cactus/Layouts/Application.cshtml" : null;
            }
        }
    }
}
