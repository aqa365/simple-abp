﻿using System;

namespace Simple.Abp.IdentityServer.Clients.Dtos
{
	public class ClientSecretDto
	{
		public virtual Guid ClientId { get; set; }

		public string Type { get; set; }

		public string Value { get; set; }

		public string Description { get; set; }

		public DateTime? Expiration { get; set; }
	}
}
