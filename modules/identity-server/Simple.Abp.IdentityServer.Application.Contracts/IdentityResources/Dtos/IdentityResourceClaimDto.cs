using System;

namespace Simple.Abp.IdentityServer.IdentityResources.Dtos
{
	public class IdentityResourceClaimDto
	{
		public Guid IdentityResourceId { get; set; }

		public string Type { get; set; }
	}
}
