using System;

namespace Simple.Abp.IdentityServer.ApiResources.Dtos
{
	public class ApiResourceClaimDto
	{
		public Guid ApiResourceId { get; set; }

		public string Type { get; set; }
	}
}
