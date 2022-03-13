using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Simple.Abp.CmsKit.Public
{
    [DependsOn(
         typeof(SimpleCmsKitPublicApplicationContractsModule)
    )]
    public class SimpleCmsKitPublicHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
