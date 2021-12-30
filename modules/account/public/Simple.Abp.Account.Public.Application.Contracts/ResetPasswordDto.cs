using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;

namespace Simple.Abp.Account
{
	public class ResetPasswordDto
	{
		public Guid UserId { get; set; }

		[Required]
		public string ResetToken { get; set; }

		[DisableAuditing]
		[Required]
		public string Password { get; set; }
	}
}
