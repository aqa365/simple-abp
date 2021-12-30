using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace Simple.Abp.Identity
{
	[DependsOn(
		typeof(AbpIdentityDomainModule),
		typeof(AbpIdentityApplicationContractsModule),
		typeof(AbpAutoMapperModule),
		typeof(AbpPermissionManagementApplicationModule),
		typeof(AbpSettingManagementDomainModule)
	)]
	public class AbpIdentityApplicationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAutoMapperObjectMapper<AbpIdentityApplicationModule>();
			Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddProfile<AbpIdentityApplicationModuleAutoMapperProfile>();
			});
		}
	}
}
