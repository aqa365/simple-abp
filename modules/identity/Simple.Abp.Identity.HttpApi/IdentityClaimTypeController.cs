﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
	[Route("api/identity/claim-types")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[ControllerName("ClaimType")]
	[Area("identity")]
	public class IdentityClaimTypeController : AbpController, IIdentityClaimTypeAppService
	{
		protected IIdentityClaimTypeAppService ClaimTypeAppService { get; }

		public IdentityClaimTypeController(IIdentityClaimTypeAppService claimTypeAppService)
		{
			ClaimTypeAppService = claimTypeAppService;
		}

		[HttpGet]
		public virtual Task<PagedResultDto<ClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input)
		{
			return this.ClaimTypeAppService.GetListAsync(input);
		}

		[Route("all")]
		[HttpGet]
		public virtual Task<List<ClaimTypeDto>> GetAllListAsync()
		{
			return this.ClaimTypeAppService.GetAllListAsync();
		}

		[Route("{id}")]
		[HttpGet]
		public virtual Task<ClaimTypeDto> GetAsync(Guid id)
		{
			return this.ClaimTypeAppService.GetAsync(id);
		}

		[HttpPost]
		public virtual Task<ClaimTypeDto> CreateAsync(CreateClaimTypeDto input)
		{
			return this.ClaimTypeAppService.CreateAsync(input);
		}

		[HttpPut]
		[Route("{id}")]
		public virtual Task<ClaimTypeDto> UpdateAsync(Guid id, UpdateClaimTypeDto input)
		{
			return this.ClaimTypeAppService.UpdateAsync(id, input);
		}

		[Route("{id}")]
		[HttpDelete]
		public virtual Task DeleteAsync(Guid id)
		{
			return this.ClaimTypeAppService.DeleteAsync(id);
		}
	}
}
