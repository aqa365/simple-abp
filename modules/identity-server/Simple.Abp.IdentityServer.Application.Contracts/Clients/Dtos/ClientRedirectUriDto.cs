using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientRedirectUriDto
	{
		public virtual Guid ClientId { get; protected set; }

		public virtual string RedirectUri { get; protected set; }
	}
}
