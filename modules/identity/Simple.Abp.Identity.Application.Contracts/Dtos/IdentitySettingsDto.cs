namespace Simple.Abp.Identity
{
	public class IdentitySettingsDto
	{
		public IdentityPasswordSettingsDto Password { get; set; }

		public IdentityLockoutSettingsDto Lockout { get; set; }

		public IdentitySignInSettingsDto SignIn { get; set; }

		public IdentityUserSettingsDto User { get; set; }
	}
}
