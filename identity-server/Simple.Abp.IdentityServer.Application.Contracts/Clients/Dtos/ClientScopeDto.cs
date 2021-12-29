using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientScopeDto
	{
		public Guid ClientId { get; set; }

		public string Scope { get; set; }
	}
}
