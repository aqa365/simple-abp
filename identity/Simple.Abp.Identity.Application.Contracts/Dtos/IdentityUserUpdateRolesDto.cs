using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Identity
{
	public class IdentityUserUpdateRolesDto
	{
		[Required]
		public string[] RoleNames { get; set; }
	}
}
