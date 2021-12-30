using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Simple.Abp.Account
{
	public class RegisterDto
	{
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxUserNameLength", null)]
		[Required]
		public string UserName { get; set; }

		[Required]
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxEmailLength", null)]
		[EmailAddress]
		public string EmailAddress { get; set; }

		[DisableAuditing]
		[Required]
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxPasswordLength", null)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string AppName { get; set; }
	}
}
