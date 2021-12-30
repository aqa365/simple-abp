using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Simple.Abp.Identity
{
	public class UpdateProfileDto : ExtensibleObject
	{
		[Required]
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxUserNameLength", null)]
		public string UserName { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxEmailLength", null)]
		public string Email { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxNameLength", null)]
		public string Name { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxSurnameLength", null)]
		public string Surname { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxPhoneNumberLength", null)]
		public string PhoneNumber { get; set; }
	}
}
