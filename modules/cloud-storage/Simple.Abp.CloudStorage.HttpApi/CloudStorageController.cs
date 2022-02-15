using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.CloudStorage
{
    [RemoteService]
    [Area("CloudStorage")]
    [ControllerName("Upload")]
    [Route("api/cloud-storage/upload")]
    public class CloudStorageController : AbpController, ICloudStorageAppService
    {

        private ICloudStorageAppService _cloudStorageAppService;

        public CloudStorageController(ICloudStorageAppService cloudStorageAppService)
        {
            _cloudStorageAppService = cloudStorageAppService;
        }

        [HttpPost]
        public Task<Uri> PostFile(IFormFile file)
        {
            return _cloudStorageAppService.PostFile(file);
        }
    }
}
