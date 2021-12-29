namespace Simple.Abp.Identity
{
	public class IdentitySignInSettingsDto
	{
		public bool RequireConfirmedEmail { get; set; }

		public bool EnablePhoneNumberConfirmation { get; set; }

		public bool RequireConfirmedPhoneNumber { get; set; }
	}
}
