using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class GetOrganizationUnitInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
