using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientCorsOriginDto
	{
		public virtual Guid ClientId { get; protected set; }

		public virtual string Origin { get; protected set; }
	}
}
