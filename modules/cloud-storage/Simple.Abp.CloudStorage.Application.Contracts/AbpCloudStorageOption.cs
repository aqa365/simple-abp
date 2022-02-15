using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Abp.CloudStorage
{
    public class AbpCloudStorageOption
    {
        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public AbpCloudStorageUploadOption Upload { get; set; }
    }

    public class AbpCloudStorageUploadOption
    {
        public int MaxLength { get; set; }
        public List<string> SupportedExtensions { get; set; }
        public string FileStoragePath { get; set; }
        public string CosStorageUri { get; set; }
        public bool IsOverrideEnabled { get; set; }
    }
}
