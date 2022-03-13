using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Simple.Abp.CmsKit.Public
{
    [DependsOn(
         typeof(SimpleCmsKitPublicApplicationContractsModule),
         typeof(AbpAutoMapperModule)
    )]
    public class SimpleCmsKitPublicApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SimpleCmsKitPublicApplicationModule>();
            base.Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SimpleCmsKitApplicationAutoMapperProfile>(true);
            });
        }
    }
}
