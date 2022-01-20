using Microsoft.AspNetCore.Authorization;
using Simple.Abp.Identity.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Simple.Abp.Identity
{
    public class IdentitySecurityLogAppService : IdentityAppServiceBase, IIdentitySecurityLogAppService
    {
        protected IIdentitySecurityLogRepository SecurityLogRepository { get; }
        public IdentitySecurityLogAppService(IIdentitySecurityLogRepository securityLogRepository)
        {
            SecurityLogRepository = securityLogRepository;
        }

        [Authorize(IdentityPermissions.SecurityLogs.Default)]
        public virtual async Task<PagedResultDto<IdentitySecurityLogDto>> GetListAsync(GetIdentitySecurityLogListInput input)
        {
            var count = await SecurityLogRepository.GetCountAsync(
                input.StartDateTime,
                input.EndDateTime,
                input.ApplicationName,
                input.Identity,
                input.ActionName,
                null,
                input.UserName,
                input.ClientId,
                input.CorrelationId);

            List<IdentitySecurityLog> source = await this.SecurityLogRepository.GetListAsync(input.Sorting, input.PageSize, input.SkipCount,
                input.StartDateTime,
                input.EndDateTime,
                input.ApplicationName,
                input.Identity,
                input.ActionName,
                null,
                input.UserName,
                input.ClientId,
                input.CorrelationId);

            return new PagedResultDto<IdentitySecurityLogDto>((long)count,
                base.ObjectMapper.Map<List<IdentitySecurityLog>, List<IdentitySecurityLogDto>>(source));
        }
    }
}
