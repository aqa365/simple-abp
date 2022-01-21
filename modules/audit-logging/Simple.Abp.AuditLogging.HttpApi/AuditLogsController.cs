using Microsoft.AspNetCore.Mvc;
using Simple.Abp.AuditLogging.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace Simple.Abp.AuditLogging
{
    [RemoteService(true, Name = "AbpAuditLogging")]
	[Controller]
	[Area("auditLogging")]
	[Route("api/audit-logging/audit-logs")]
	[ControllerName("AuditLogs")]
	[DisableAuditing]
	public class AuditLogsController : AbpController, IAuditLogsAppService
	{
		protected IAuditLogsAppService AuditLogsAppService { get; }

		public AuditLogsController(IAuditLogsAppService auditLogsAppService)
		{
			this.AuditLogsAppService = auditLogsAppService;
		}

		[Route("")]
		[HttpGet]
		public virtual async Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogListDto input)
		{
			return await this.AuditLogsAppService.GetListAsync(input);
		}

		[Route("{id}")]
		[HttpGet]
		public virtual async Task<AuditLogDto> GetAsync(Guid id)
		{
			return await this.AuditLogsAppService.GetAsync(id);
		}

		[HttpGet]
		[Route("statistics/error-rate")]
		public virtual async Task<GetErrorRateOutput> GetErrorRateAsync(GetErrorRateFilter filter)
		{
			return await this.AuditLogsAppService.GetErrorRateAsync(filter);
		}

		[HttpGet]
		[Route("statistics/average-execution-duration-per-day")]
		public virtual async Task<GetAverageExecutionDurationPerDayOutput> GetAverageExecutionDurationPerDayAsync(GetAverageExecutionDurationPerDayInput filter)
		{
			return await this.AuditLogsAppService.GetAverageExecutionDurationPerDayAsync(filter);
		}

		[Route("entity-changes/")]
		[HttpGet]
		public virtual async Task<PagedResultDto<EntityChangeDto>> GetEntityChangesAsync(GetEntityChangesDto input)
		{
			return await this.AuditLogsAppService.GetEntityChangesAsync(input);
		}

		[Route("entity-changes-with-username/")]
		[HttpGet]
		public virtual async Task<List<EntityChangeWithUsernameDto>> GetEntityChangesWithUsernameAsync(EntityChangeFilter input)
		{
			return await this.AuditLogsAppService.GetEntityChangesWithUsernameAsync(input);
		}

		[Route("entity-change-with-username/{entityChangeId}")]
		[HttpGet]
		public virtual async Task<EntityChangeWithUsernameDto> GetEntityChangeWithUsernameAsync(Guid entityChangeId)
		{
			return await this.AuditLogsAppService.GetEntityChangeWithUsernameAsync(entityChangeId);
		}

		[HttpGet]
		[Route("entity-changes/{entityChangeId}")]
		public virtual async Task<EntityChangeDto> GetEntityChangeAsync(Guid entityChangeId)
		{
			return await this.AuditLogsAppService.GetEntityChangeAsync(entityChangeId);
		}
	}
}
