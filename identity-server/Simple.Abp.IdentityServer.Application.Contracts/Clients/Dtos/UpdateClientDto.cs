using System;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class UpdateClientDto : ExtensibleObject
	{
		public string ClientName { get; set; }

		public string Description { get; set; }

		public string ClientUri { get; set; }

		public string LogoUri { get; set; }

		public bool Enabled { get; set; }

		public bool RequireConsent { get; set; }

		public bool AllowOfflineAccess { get; set; }

		public bool AllowRememberConsent { get; set; }

		public bool RequirePkce { get; set; }

		public bool RequireClientSecret { get; set; }

		public int AccessTokenLifetime { get; set; }

		public int? ConsentLifetime { get; set; }

		public int AccessTokenType { get; set; }

		public bool EnableLocalLogin { get; set; }

		public string FrontChannelLogoutUri { get; set; }

		public bool FrontChannelLogoutSessionRequired { get; set; }

		public string BackChannelLogoutUri { get; set; }

		public bool BackChannelLogoutSessionRequired { get; set; }

		public bool IncludeJwtId { get; set; }

		public bool AlwaysSendClientClaims { get; set; }

		public string PairWiseSubjectSalt { get; set; }

		public int? UserSsoLifetime { get; set; }

		public string UserCodeType { get; set; }

		public int DeviceCodeLifetime { get; set; }

		public ClientSecretDto[] ClientSecrets { get; set; }

		public ClientClaimDto[] Claims { get; set; }

		public ClientPropertyDto[] Properties { get; set; }

		public string[] AllowedGrantTypes { get; set; }

		public string[] IdentityProviderRestrictions { get; set; }

		public string[] Scopes { get; set; }

		public string[] AllowedCorsOrigins { get; set; }

		public string[] RedirectUris { get; set; }

		public string[] PostLogoutRedirectUris { get; set; }
	}
}
