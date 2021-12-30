using System;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.ApiResources.Dtos
{
	public class UpdateApiResourceDto : ExtensibleObject
	{
		public string DisplayName { get; set; }

		public string Description { get; set; }

		public bool Enabled { get; set; }

		public bool ShowInDiscoveryDocument { get; set; }

		public Dictionary<string, string> Properties { get; set; }

		public ApiResourceClaimDto[] UserClaims { get; set; }

		public ApiResourceScopeDto[] Scopes { get; set; }

		public ApiResourceSecretDto[] Secrets { get; set; }
	}
}
