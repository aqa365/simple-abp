using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Simple.Abp.Account
{
	public class SendPasswordResetCodeDto
	{
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxEmailLength", null)]
		[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required]
		public string AppName { get; set; }
	}
}
