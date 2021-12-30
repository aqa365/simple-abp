using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class GetIdentityRoleListInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
