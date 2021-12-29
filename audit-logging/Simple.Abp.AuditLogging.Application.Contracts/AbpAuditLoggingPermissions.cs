using Volo.Abp.Reflection;

namespace Simple.Abp.AuditLogging
{
    public class AbpAuditLoggingPermissions
	{
		public static string[] GetAll()
		{
			return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpAuditLoggingPermissions));
		}

		public const string GroupName = "AuditLogging";

		public class AuditLogs
		{
			public const string Default = "AuditLogging.AuditLogs";
		}
	}
}
