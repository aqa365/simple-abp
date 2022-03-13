using Volo.Abp.Application.Services;
using Volo.CmsKit.Localization;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleCmsKitPublicAppServiceBase: ApplicationService
    {
        protected SimpleCmsKitPublicAppServiceBase()
        {
            LocalizationResource = typeof(CmsKitResource);
            ObjectMapperContext = typeof(SimpleCmsKitPublicApplicationModule);
        }
    }
}
