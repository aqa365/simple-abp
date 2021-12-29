using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class GetIdentityClaimTypesInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }

	}
}
