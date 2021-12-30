using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientGrantTypeDto
	{
		public Guid ClientId { get; set; }

		public string GrantType { get; set; }
	}
}
