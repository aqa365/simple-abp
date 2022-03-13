using Volo.Abp.Modularity;
using Volo.CmsKit;

namespace Simple.Abp.CmsKit.Public
{
    [DependsOn(
         typeof(CmsKitApplicationContractsModule)
    )]
    public class SimpleCmsKitPublicApplicationContractsModule:AbpModule
    {
    }
}
