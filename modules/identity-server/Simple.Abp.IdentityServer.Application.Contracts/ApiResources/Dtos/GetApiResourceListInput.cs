using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.ApiResources.Dtos
{
	public class GetApiResourceListInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
