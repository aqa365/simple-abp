using Volo.Abp.Auditing;

namespace Simple.Abp.Identity
{
	public class ChangePasswordInput
	{
		[DisableAuditing]
		public string CurrentPassword { get; set; }

		[DisableAuditing]
		public string NewPassword { get; set; }
	}
}
