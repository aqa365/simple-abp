using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.ClaimTypes.Dtos
{
	public class IdentityClaimTypeDto : ExtensibleEntityDto<Guid>
	{
		public string Name { get; set; }
	}
}
