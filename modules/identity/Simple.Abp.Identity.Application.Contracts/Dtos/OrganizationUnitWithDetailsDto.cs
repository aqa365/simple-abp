﻿using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Identity
{
	public class OrganizationUnitWithDetailsDto : ExtensibleFullAuditedEntityDto<Guid>
	{
		public Guid? ParentId { get; set; }

		public string Code { get; set; }

		public string DisplayName { get; set; }

		public List<IdentityRoleDto> Roles { get; set; }
	}
}
