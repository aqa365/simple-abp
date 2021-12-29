using Volo.Abp.Domain.Entities;

namespace Simple.Abp.Identity
{
	public class IdentityRoleUpdateDto : IdentityRoleCreateOrUpdateDtoBase, IHasConcurrencyStamp
	{
		public string ConcurrencyStamp { get; set; }
	}
}
