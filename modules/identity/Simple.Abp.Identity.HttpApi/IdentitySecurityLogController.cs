using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Identity.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Identity
{
    [ControllerName("SecurityLog")]
    [Route("api/identity/security-logs")]
    [RemoteService(true, Name = IdentityProRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    public class IdentitySecurityLogController : AbpController, IIdentitySecurityLogAppService
    {
        protected IIdentitySecurityLogAppService SecurityLogAppService { get; }

        public IdentitySecurityLogController(IIdentitySecurityLogAppService securityLogAppService)
        {
            SecurityLogAppService = securityLogAppService;
        }


        [HttpGet]
        public Task<PagedResultDto<IdentitySecurityLogDto>> GetListAsync(GetIdentitySecurityLogListInput input)
        {
            return SecurityLogAppService.GetListAsync(input);
        }
    }
}
