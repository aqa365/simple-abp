using Microsoft.AspNetCore.Authorization;
using Simple.Abp.AuditLogging.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Json;

namespace Simple.Abp.AuditLogging
{
    [DisableAuditing]
    [Authorize("AuditLogging.AuditLogs")]
    public class AuditLogsAppService : AuditLogsAppServiceBase, IAuditLogsAppService
    {
        protected IAuditLogRepository AuditLogRepository { get; }

        protected IJsonSerializer JsonSerializer { get; }

        protected IPermissionChecker PermissionChecker { get; }

        protected IPermissionDefinitionManager PermissionDefinitionManager { get; }

        public AuditLogsAppService(IAuditLogRepository auditLogRepository, IJsonSerializer jsonSerializer, IPermissionChecker permissionChecker, IPermissionDefinitionManager permissionDefinitionManager)
        {
            this.AuditLogRepository = auditLogRepository;
            this.JsonSerializer = jsonSerializer;
            this.PermissionChecker = permissionChecker;
            this.PermissionDefinitionManager = permissionDefinitionManager;
        }

        public virtual async Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogListDto input)
        {
            List<AuditLog> auditLogs = await AuditLogRepository.GetListAsync(
                sorting: input.Sorting,
                maxResultCount: input.MaxResultCount,
                skipCount: input.SkipCount,
                startTime: null,
                endTime: null,
                httpMethod: input.HttpMethod,
                url: input.Url,
                userName: input.UserName,
                applicationName: input.ApplicationName,
                correlationId: input.CorrelationId,
                maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration,
                hasException: input.HasException,
                httpStatusCode: input.HttpStatusCode,
                includeDetails: false
            );

            long num = await AuditLogRepository.GetCountAsync(
                startTime: null,
                endTime: null,
                httpMethod: input.HttpMethod,
                url: input.Url,
                userName: input.UserName,
                applicationName: input.ApplicationName,
                correlationId: input.CorrelationId,
                maxExecutionDuration: input.MaxExecutionDuration,
                minExecutionDuration: input.MinExecutionDuration,
                hasException: input.HasException,
                httpStatusCode: input.HttpStatusCode
            );

            List<AuditLogDto> list2 = base.ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(auditLogs);
            return new PagedResultDto<AuditLogDto>(num, list2);
        }

        public virtual async Task<AuditLogDto> GetAsync(Guid id)
        {
            AuditLog auditLog = await this.AuditLogRepository.GetAsync(id);
            var auditLogDto = base.ObjectMapper.Map<AuditLog, AuditLogDto>(auditLog);
            foreach (var auditLogActionDto in auditLogDto.Actions)
            {
                object obj = this.JsonSerializer.Deserialize<object>(auditLogActionDto.Parameters, true);
                auditLogActionDto.Parameters = this.JsonSerializer.Serialize(obj, true, true);
            }
            return auditLogDto;
        }

        public virtual async Task<GetErrorRateOutput> GetErrorRateAsync(GetErrorRateFilter filter)
        {
            long successfulLogCount = await this.AuditLogRepository.GetCountAsync(
               startTime: filter.StartDate,
               endTime: filter.EndDate.AddDays(1.0)
            );

            long value = await this.AuditLogRepository.GetCountAsync(
               startTime: filter.StartDate,
               endTime: filter.EndDate.AddDays(1.0)
            );

            return new GetErrorRateOutput
            {
                Data = new Dictionary<string, long>
                {
                    {
                        base.L["Fault"],
                        value
                    },
                    {
                        base.L["Success"],
                        successfulLogCount
                    }
                }
            };
        }

        public virtual async Task<GetAverageExecutionDurationPerDayOutput> GetAverageExecutionDurationPerDayAsync(GetAverageExecutionDurationPerDayInput filter)
        {
            var source = await this.AuditLogRepository.GetAverageExecutionDurationPerDayAsync(filter.StartDate, filter.EndDate);
            var getAverageExecutionDurationPerDayOutput = new GetAverageExecutionDurationPerDayOutput();
            getAverageExecutionDurationPerDayOutput.Data = source.ToDictionary((KeyValuePair<DateTime, double> x) => x.Key.ToString("d"), (KeyValuePair<DateTime, double> x) => x.Value);
            return getAverageExecutionDurationPerDayOutput;
        }

        public virtual async Task<PagedResultDto<EntityChangeDto>> GetEntityChangesAsync(GetEntityChangesDto input)
        {
            List<EntityChange> list = await this.AuditLogRepository.GetEntityChangeListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.AuditLogId, input.StartDate, input.EndDate, input.EntityChangeType, input.EntityId, input.EntityTypeFullName, true);
            List<EntityChange> entityChanges = list;
            long num = await this.AuditLogRepository.GetEntityChangeCountAsync(input.AuditLogId, input.StartDate, input.EndDate, input.EntityChangeType, input.EntityId, input.EntityTypeFullName);
            List<EntityChangeDto> list2 = base.ObjectMapper.Map<List<EntityChange>, List<EntityChangeDto>>(entityChanges);
            return new PagedResultDto<EntityChangeDto>(num, list2);
        }

        [AllowAnonymous]
        public virtual async Task<List<EntityChangeWithUsernameDto>> GetEntityChangesWithUsernameAsync(EntityChangeFilter input)
        {
            await this.CheckPermissionForEntity(input.EntityTypeFullName);
            var list = await this.AuditLogRepository.GetEntityChangesWithUsernameAsync(input.EntityId, input.EntityTypeFullName);
            return base.ObjectMapper.Map<List<EntityChangeWithUsername>, List<EntityChangeWithUsernameDto>>(list);
        }

        public virtual async Task<EntityChangeWithUsernameDto> GetEntityChangeWithUsernameAsync(Guid entityChangeId)
        {
            var entityChangeWithUsername = await this.AuditLogRepository.GetEntityChangeWithUsernameAsync(entityChangeId);
            return base.ObjectMapper.Map<EntityChangeWithUsername, EntityChangeWithUsernameDto>(entityChangeWithUsername);
        }

        public virtual async Task<EntityChangeDto> GetEntityChangeAsync(Guid entityChangeId)
        {
            var entityChange = await this.AuditLogRepository.GetEntityChange(entityChangeId);
            return base.ObjectMapper.Map<EntityChange, EntityChangeDto>(entityChange);
        }

        protected virtual async Task CheckPermissionForEntity(string entityFullName)
        {
            string text = "AuditLogging.ViewChangeHistory:" + entityFullName;
            if (this.PermissionDefinitionManager.GetOrNull(text) == null)
            {
                await base.AuthorizationService.CheckAsync("AuditLogging.AuditLogs");
            }
            else
            {
                var flag = await this.PermissionChecker.IsGrantedAsync(text);
                if (!flag)
                {
                    await base.AuthorizationService.CheckAsync("AuditLogging.AuditLogs");
                }
            }
        }
    }
}
