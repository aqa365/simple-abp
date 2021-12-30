using Simple.Abp.Articles.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles
{
    /* Inherit your controllers from this class.
     */
    public abstract class ArticlesController : AbpController
    {
        protected ArticlesController()
        {
            LocalizationResource = typeof(ArticlesResource);
        }
    }
}