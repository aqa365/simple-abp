using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Simple.Abp.Identity
{
	public abstract class IdentityUserCreateOrUpdateDtoBase : ExtensibleObject
	{
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxUserNameLength", null)]
		[Required]
		public string UserName { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxNameLength", null)]
		public string Name { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxSurnameLength", null)]
		public string Surname { get; set; }

		[EmailAddress]
		[Required]
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxEmailLength", null)]
		public string Email { get; set; }

		[DynamicStringLength(typeof(IdentityUserConsts), "MaxPhoneNumberLength", null)]
		public string PhoneNumber { get; set; }

		public bool TwoFactorEnabled { get; set; }

		public bool LockoutEnabled { get; set; }

		public string[] RoleNames { get; set; }

		public Guid[] OrganizationUnitIds { get; set; }

		protected IdentityUserCreateOrUpdateDtoBase()
			: base(false)
		{
		}
	}
}
