using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Simple.Abp.Identity
{
	public class IdentityRoleCreateOrUpdateDtoBase : ExtensibleObject
	{
		[DynamicStringLength(typeof(IdentityRoleConsts), "MaxNameLength", null)]
		[Required]
		public string Name { get; set; }

		public bool IsDefault { get; set; }

		public bool IsPublic { get; set; }

		protected IdentityRoleCreateOrUpdateDtoBase()
			: base(false)
		{
		}
	}
}
