using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.AntdTheme
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class AbpAntdThemeManagementApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAntdThemeManagementApplicationContractsModule>("Simple.Abp.AntdTheme");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AntdThemeResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("Localization/SimpleAbpAntdTheme");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.AntdTheme", typeof(AntdThemeResource)));
        }

    }
}
