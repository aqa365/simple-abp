using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientPropertyDto
	{
		public virtual Guid ClientId { get; set; }

		public virtual string Key { get; set; }

		public virtual string Value { get; set; }
	}
}
