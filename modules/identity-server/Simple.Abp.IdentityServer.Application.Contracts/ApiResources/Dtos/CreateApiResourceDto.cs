using System;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.ApiResources.Dtos
{
	public class CreateApiResourceDto : ExtensibleObject
	{
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public bool ShowInDiscoveryDocument { get; set; }

		public List<ApiResourceClaimDto> UserClaims { get; set; }
	}
}
