using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Identity
{
	public class IdentityPasswordSettingsDto
	{
		[Range(2, 128)]
		public int RequiredLength { get; set; }

		[Range(1, 128)]
		public int RequiredUniqueChars { get; set; }

		public bool RequireNonAlphanumeric { get; set; }

		public bool RequireLowercase { get; set; }

		public bool RequireUppercase { get; set; }

		public bool RequireDigit { get; set; }
	}
}
