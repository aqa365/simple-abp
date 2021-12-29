namespace Simple.Abp.AuditLogging.Dtos
{
    public class EntityChangeWithUsernameDto
    {
        public EntityChangeDto EntityChange { get; set; }

        public string UserName { get; set; }
    }
}
