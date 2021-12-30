using System;

namespace Simple.Abp.Identity
{
	public class IdentityRoleClaimDto
	{
		public Guid RoleId { get; set; }

		public string ClaimType { get; set; }

		public string ClaimValue { get; set; }
	}
}
