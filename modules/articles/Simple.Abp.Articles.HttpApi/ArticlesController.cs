using Simple.Abp.Articles;
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