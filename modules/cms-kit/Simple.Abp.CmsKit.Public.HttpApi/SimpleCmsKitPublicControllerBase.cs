using Volo.Abp.AspNetCore.Mvc;
using Volo.CmsKit.Localization;

namespace Simple.Abp.CmsKit.Public
{
    public abstract class  SimpleCmsKitPublicControllerBase : AbpControllerBase
    {
        protected SimpleCmsKitPublicControllerBase()
        {
            LocalizationResource = typeof(CmsKitResource);
        }
    }
}
