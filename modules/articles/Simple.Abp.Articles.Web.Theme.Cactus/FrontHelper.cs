using Microsoft.AspNetCore.Http;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.Articles.Web.Theme.Cactus
{
    public enum EnumCactusTheme
    {
        Default,
        Light
    }

    public class FrontHelper: IScopedDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FrontHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public EnumCactusTheme GetCurrentTheme()
        {
            string theme = string.Empty;
            _httpContextAccessor.HttpContext.Request.Cookies
                .TryGetValue("theme", out theme);
            switch (theme)
            {
                case "light":
                    return EnumCactusTheme.Light;
                default:
                    return EnumCactusTheme.Default;
            }
        }

    }
}
