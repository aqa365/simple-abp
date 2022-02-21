using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Volo.CmsKit.Users;

namespace Simple.Abp.Test.CmsKit.Users
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    public class MyCmsUserLookupService : CmsUserLookupService, ICmsUserLookupService
    {
        public MyCmsUserLookupService(ICmsUserRepository userRepository, IUnitOfWorkManager unitOfWorkManager) 
            : base(userRepository, unitOfWorkManager)
        {
        }
    }
}
