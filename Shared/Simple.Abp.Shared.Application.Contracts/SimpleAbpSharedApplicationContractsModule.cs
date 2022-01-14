using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Shared
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpValidationModule)
    )]
    public class SimpleAbpSharedApplicationContractsModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<SimpleAbpSharedApplicationContractsModule>("Simple.Abp.Shared");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<SimpleAbpShardResource>("en")
                    .AddVirtualJson("Localization/SimpleAbpShard");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.Shared", typeof(SimpleAbpShardResource)));
        }
    }
}
