using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.Identity
{
	public abstract class OrganizationUnitCreateOrUpdateDtoBase : ExtensibleObject
	{
		[Required]
		[StringLength(128)]
		public string DisplayName { get; set; }
	}
}
