using System;

namespace Simple.Abp.Identity
{
	public class OrganizationUnitCreateDto : OrganizationUnitCreateOrUpdateDtoBase
	{
		public Guid? ParentId { get; set; }
	}
}
