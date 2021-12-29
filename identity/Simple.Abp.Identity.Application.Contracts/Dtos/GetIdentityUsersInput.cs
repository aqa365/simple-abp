using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
