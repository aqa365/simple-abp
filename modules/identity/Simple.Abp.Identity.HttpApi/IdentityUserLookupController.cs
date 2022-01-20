using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Simple.Abp.Identity
{
    [Area("identity")]
	[ControllerName("UserLookup")]
	[RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
	[Route("api/identity/users/lookup")]
	public class IdentityUserLookupController : AbpController, IIdentityUserLookupAppService
	{
		protected IIdentityUserLookupAppService LookupAppService { get; }

		public IdentityUserLookupController(IIdentityUserLookupAppService lookupAppService)
		{
			LookupAppService = lookupAppService;
		}

		[HttpGet]
		[Route("{id}")]
		public virtual Task<UserData> FindByIdAsync(Guid id)
		{
			return this.LookupAppService.FindByIdAsync(id);
		}

		[HttpGet]
		[Route("by-username/{userName}")]
		public virtual Task<UserData> FindByUserNameAsync(string userName)
		{
			return this.LookupAppService.FindByUserNameAsync(userName);
		}

		[Route("search")]
		[HttpGet]
		public Task<ListResultDto<UserData>> SearchAsync(UserLookupSearchInputDto input)
		{
			return this.LookupAppService.SearchAsync(input);
		}

		[Route("count")]
		[HttpGet]
		public Task<long> GetCountAsync(UserLookupCountInputDto input)
		{
			return this.LookupAppService.GetCountAsync(input);
		}
	}
}
