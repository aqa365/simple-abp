using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class UserLookupSearchInputDto : PagedResultRequestDto, ISortedResultRequest
	{
		public string Sorting { get; set; }

		public string Filter { get; set; }
	}
}
