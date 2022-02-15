using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace Simple.Abp.CloudStorage
{
    public interface ICloudStorageAppService: IApplicationService, ITransientDependency
    {
        Task<Uri> PostFile(IFormFile file);
    }
}
