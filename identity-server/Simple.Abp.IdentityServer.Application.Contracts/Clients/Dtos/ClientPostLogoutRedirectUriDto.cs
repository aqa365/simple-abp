using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientPostLogoutRedirectUriDto
	{
		public virtual Guid ClientId { get; protected set; }

		public virtual string PostLogoutRedirectUri { get; protected set; }
	}
}
