using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.IdentityResources.Dtos
{
	public class GetIdentityResourceListInput : PagedAndSortedResultRequestDto
	{
		public string Filter { get; set; }
	}
}
