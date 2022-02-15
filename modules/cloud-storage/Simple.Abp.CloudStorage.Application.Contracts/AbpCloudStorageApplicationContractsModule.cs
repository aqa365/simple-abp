using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Myvas.AspNetCore.TencentCos;
using Volo.Abp.Application;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.CloudStorage
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule)
    )]
    public class AbpCloudStorageApplicationContractsModule : AbpModule
    {
        private void ConfigureCloudStorage(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var section = configuration.GetSection("CloudStorage");
            var cloudStorageOption = section.Get<AbpCloudStorageOption>();

            if (cloudStorageOption != null)
            {
                Configure<AbpCloudStorageOption>(section);
                Configure<TencentCosOptions>(section);
            }

            //Configure<AbpCloudStorageOption>(options => { });
            context.Services.AddTencentCos(options => { });
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {

        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpCloudStorageApplicationContractsModule>("Simple.Abp.CloudStorage");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                .Add<AbpCloudStorageResource>()
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/SimpleAbpCloudStorage");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
                options.MapCodeNamespace("Simple.Abp.CloudStorage", typeof(AbpCloudStorageResource)));

            ConfigureCloudStorage(context);
        }
    }
}
