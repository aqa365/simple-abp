using Simple.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Account
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule)
    )]
    public class AbpAccountSharedApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
                options.FileSets.AddEmbedded<AbpAccountSharedApplicationContractsModule>("Simple.Abp.Account")
            );

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AccountResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("Localization/SimpleAbpAccount");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.Account", typeof(AccountResource)));
        }
    }
}
