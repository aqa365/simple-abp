using Simple.Abp.CmsKit.Public.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.CmsKit.Public
{
    public interface ISimpleBlogPostPublicAppService : IApplicationService, ITransientDependency
    {
        Task<SimpleBlogPostDto> GetPreviousAsync(Guid blogId, Guid blogPostId, DateTime creationTime);

        Task<SimpleBlogPostDto> GetNextAsync(Guid blogId, Guid blogPostId,DateTime creationTime);

        Task<SimpleBlogPostDto> GetAsync(string blogSlug,string blogPostSlug);

        Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input);

        Task<PagedResultDto<SimpleBlogPostDto>> GetListByTagAsync(string tagName, SimpleBlogPostGetListInput input);
    }
}
