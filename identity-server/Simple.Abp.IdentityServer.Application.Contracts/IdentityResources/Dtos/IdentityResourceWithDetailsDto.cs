using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.IdentityResources.Dtos
{
	public class IdentityResourceWithDetailsDto : ExtensibleEntityDto<Guid>
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public bool Enabled { get; set; }

		public bool Required { get; set; }

		public bool Emphasize { get; set; }

		public bool ShowInDiscoveryDocument { get; set; }

		public List<IdentityResourceClaimDto> UserClaims { get; set; }

		public Dictionary<string, string> Properties { get; set; }
	}
}
