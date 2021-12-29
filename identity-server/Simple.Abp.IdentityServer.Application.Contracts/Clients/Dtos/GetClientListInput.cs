using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class GetClientListInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
