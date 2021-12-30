namespace Simple.Abp.AuditLogging
{
    public class AuditLogDtoCommonConsts
	{
		public static int UrlFilterMaxLength { get; set; }

		public static int UserNameFilterMaxLength { get; set; }

		public static int HttpMethodFilterMaxLength { get; set; }

		static AuditLogDtoCommonConsts()
		{
			UrlFilterMaxLength = 512;
			UserNameFilterMaxLength = 128;
			HttpMethodFilterMaxLength = 16;
		}
	}
}
