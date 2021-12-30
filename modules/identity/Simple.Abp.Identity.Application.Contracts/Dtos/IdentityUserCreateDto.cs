using System.ComponentModel.DataAnnotations;
using Volo.Abp.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Simple.Abp.Identity
{
	public class IdentityUserCreateDto : IdentityUserCreateOrUpdateDtoBase
	{
		[DisableAuditing]
		[DynamicStringLength(typeof(IdentityUserConsts), "MaxPasswordLength", null)]
		[Required]
		public string Password { get; set; }
	}
}
