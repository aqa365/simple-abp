using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientIdentityProviderRestrictionDto
	{
		public Guid ClientId { get; set; }

		public string Provider { get; set; }
	}
}
