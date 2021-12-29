namespace Simple.Abp.Identity
{
	public class IdentityUserUpdatePasswordInput
	{
		public string NewPassword { get; set; }

		public IdentityUserUpdatePasswordInput(string newPassword)
		{
			NewPassword = newPassword;
		}
	}
}
