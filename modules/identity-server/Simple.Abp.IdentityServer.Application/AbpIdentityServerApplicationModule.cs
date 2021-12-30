using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.IdentityServer;
using Volo.Abp.AutoMapper;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace Simple.Abp.IdentityServer
{
    [DependsOn(
		typeof(AbpIdentityServerApplicationContractsModule),
		typeof(AbpAutoMapperModule),
		typeof(AbpIdentityServerDomainModule)
	)]
	public class AbpIdentityServerApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAutoMapperObjectMapper<AbpIdentityServerApplicationModule>();

			Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddProfile<AbpIdentityServerApplicationAutoMapperProfile>(true);
			});
		}
	}
}
