using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public
{
    public interface ISimpleTagPublicAppService : IApplicationService,ITransientDependency
    {
        Task<List<TagDto>> GetAllAsync();
    }
}
