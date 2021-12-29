using System;

namespace Simple.Abp.Identity
{
	public class IdentityUserClaimDto
	{
		public Guid UserId { get; set; }

		public string ClaimType { get; set; }

		public string ClaimValue { get; set; }
	}
}
