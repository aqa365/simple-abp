namespace Simple.Abp.Identity
{
	public class IdentityLockoutSettingsDto
	{
		public bool AllowedForNewUsers { get; set; }

		public int LockoutDuration { get; set; }

		public int MaxFailedAccessAttempts { get; set; }
	}
}
