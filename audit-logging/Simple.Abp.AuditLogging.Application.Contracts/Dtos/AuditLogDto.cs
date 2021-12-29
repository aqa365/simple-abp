using Volo.Abp.Application.Dtos;

namespace Simple.Abp.AuditLogging.Dtos
{
    public class AuditLogDto : ExtensibleEntityDto<Guid>
    {
        public Guid? UserId { get; set; }

        public string UserName { get; set; }

        public Guid? TenantId { get; set; }

        public Guid? ImpersonatorUserId { get; set; }

        public Guid? ImpersonatorTenantId { get; set; }

        public DateTime ExecutionTime { get; set; }

        public int ExecutionDuration { get; set; }

        public string ClientIpAddress { get; set; }

        public string ClientName { get; set; }

        public string BrowserInfo { get; set; }

        public string HttpMethod { get; set; }

        public string Url { get; set; }

        public string Exceptions { get; set; }

        public string Comments { get; set; }

        public int? HttpStatusCode { get; set; }

        public string ApplicationName { get; set; }

        public string CorrelationId { get; set; }

        public List<EntityChangeDto> EntityChanges { get; set; }

        public List<AuditLogActionDto> Actions { get; set; }
    }
}
