using System;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class CreateClientDto : ExtensibleObject
	{
		public string ClientId { get; set; }

		public string ClientName { get; set; }

		public string Description { get; set; }

		public string ClientUri { get; set; }

		public string LogoUri { get; set; }

		public bool RequireConsent { get; set; }

		public string CallbackUrl { get; set; }

		public string LogoutUrl { get; set; }

		public ClientSecretDto[] Secrets { get; set; }

		public string[] Scopes { get; set; }
	}
}
