using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Account.Public.Web
{
    [ThemeName(Name)]
    public class SimpleAccountPublicTheme : ITransientDependency, ITheme
    {
        public const string Name = "Cactus";
        public string GetLayout(string name, bool fallbackToDefault = true)
        {
            switch (name)
            {
                case StandardLayouts.Account:
                    return "~/Pages/Shared/Account.cshtml";
                default:
                    return "~/Pages/Shared/Account.cshtml";
            }
        }
    }
}
