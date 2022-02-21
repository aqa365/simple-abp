using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Users;
using Volo.CmsKit.GlobalFeatures;
using Volo.CmsKit.Users;

namespace Simple.Abp.Test.CmsKit.Users
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    public class MyCmsUserSynchronizer : CmsUserSynchronizer, 
        IDistributedEventHandler<EntityUpdatedEto<UserEto>>,
        IDistributedEventHandler<EntityCreatedEto<UserEto>>,
        ITransientDependency
    {
        public MyCmsUserSynchronizer(ICmsUserRepository userRepository, 
            ICmsUserLookupService userLookupService) 
            : base(userRepository, userLookupService)
        {

        }
        public override Task HandleEventAsync(EntityUpdatedEto<UserEto> eventData)
        {
            return base.HandleEventAsync(eventData);
        }

        public async Task HandleEventAsync(EntityCreatedEto<UserEto> eventData)
        {
            if (!GlobalFeatureManager.Instance.IsEnabled<CmsUserFeature>())
            {
                return;
            }
        }
    }
}
