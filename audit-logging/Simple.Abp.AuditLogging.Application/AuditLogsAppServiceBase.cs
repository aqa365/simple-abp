using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging.Localization;

namespace Simple.Abp.AuditLogging
{
    public abstract class AuditLogsAppServiceBase : ApplicationService
	{
		protected AuditLogsAppServiceBase()
		{
			base.ObjectMapperContext = typeof(AbpAuditLoggingApplicationModule);
			base.LocalizationResource = typeof(AuditLoggingResource);
		}
	}
}
