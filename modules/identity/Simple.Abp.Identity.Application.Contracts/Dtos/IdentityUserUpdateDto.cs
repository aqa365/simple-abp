using Volo.Abp.Domain.Entities;

namespace Simple.Abp.Identity
{
	public class IdentityUserUpdateDto : IdentityUserCreateOrUpdateDtoBase, IHasConcurrencyStamp
	{
		public string ConcurrencyStamp { get; set; }
	}
}
