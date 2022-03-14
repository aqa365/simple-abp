using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.CmsKit.Admin.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public interface IBlogPublicAppService : IApplicationService,ITransientDependency
    {
        Task<List<BlogDto>> GetAllAsync();
    }
}
