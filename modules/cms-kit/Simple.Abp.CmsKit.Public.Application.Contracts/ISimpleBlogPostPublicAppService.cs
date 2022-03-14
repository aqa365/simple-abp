using Simple.Abp.CmsKit.Public.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.CmsKit.Public
{
    public interface ISimpleBlogPostPublicAppService : IApplicationService, ITransientDependency
    {
        Task<SimpleBlogPostDto> GetAsync(string blogSlug,string blogPostSlug);

        Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input);
    }
}
