using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Myvas.AspNetCore.TencentCos;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Simple.Abp.CloudStorage
{
    public class TencentCloudStorageAppService : ApplicationService, ICloudStorageAppService
    {
        private readonly AbpCloudStorageOption _cloudStorageOption;
        private readonly ITencentCosHandler _cosHandler;

        public TencentCloudStorageAppService( IOptions<AbpCloudStorageOption> tencentCosOption,ITencentCosHandler cosHandler)
        {
            _cloudStorageOption = tencentCosOption.Value;
            _cosHandler = cosHandler;

            ObjectMapperContext = typeof(AbpCloudStorageApplicationModule);
            LocalizationResource = typeof(AbpCloudStorageResource);
        }

        [Authorize(CloudStoragePermissions.CloudStorage.Uploads)]
        public async Task<Uri> PostFile(IFormFile file)
        {
            if (file == null)
                throw new ArgumentNullException("文件为空", nameof(file));

            var uploadOptions = _cloudStorageOption.Upload;

            if (file.Length > uploadOptions.MaxLength)
                throw new ArgumentOutOfRangeException($"只能上传小于{uploadOptions.MaxLength / 1024}M的文件");

            string extension = Path.GetExtension(file.FileName);
            if (extension == null)
                throw new ArgumentOutOfRangeException("文件没有扩展名");

            extension = extension.ToLowerInvariant();
            if (!uploadOptions.SupportedExtensions.Contains(extension))
                throw new ArgumentOutOfRangeException("暂不支持该文件上传");

            var buckets = await _cosHandler.AllBucketsAsync();
            var storageUri = uploadOptions.CosStorageUri;
            var containerExists = await _cosHandler.ExistsAsync(storageUri);
            if (!containerExists)
                throw new ArgumentOutOfRangeException("bucket不存在");

            var filePath = new Uri(new Uri(storageUri), file.FileName);
            var fileExists = await _cosHandler.ExistsAsync(filePath.ToString());
            if (fileExists && !uploadOptions.IsOverrideEnabled)
                throw new ArgumentOutOfRangeException("文件已存在");

            var uploadedUri = await _cosHandler.PutObjectAsync(filePath.ToString(), file.OpenReadStream());
            return uploadedUri;
        }
    }
}
