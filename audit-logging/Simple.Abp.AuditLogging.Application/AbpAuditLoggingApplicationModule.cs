using Microsoft.Extensions.DependencyInjection;
using Simple.Abp.AuditLogging.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;

namespace Simple.Abp.AuditLogging
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpAuditLoggingDomainModule)
        )]
    public class AbpAuditLoggingApplicationModule : AbpModule
    {
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			context.Services.AddAutoMapperObjectMapper<AbpAuditLoggingApplicationModule>();
			base.Configure<AbpAutoMapperOptions>(options =>
			{
				options.AddProfile<AbpAuditLoggingApplicationAutoMapperProfile>(true);
			});
		}

		public override void PostConfigureServices(ServiceConfigurationContext context)
		{
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("AuditLogging", "AuditLog", new Type[]
			{
				typeof(AuditLogDto)
			}, null, null);
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("AuditLogging", "AuditLogAction", new Type[]
			{
				typeof(AuditLogAction)
			}, null, null);
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("AuditLogging", "EntityChange", new Type[]
			{
				typeof(EntityChangeDto)
			}, null, null);
		}
	}
}
