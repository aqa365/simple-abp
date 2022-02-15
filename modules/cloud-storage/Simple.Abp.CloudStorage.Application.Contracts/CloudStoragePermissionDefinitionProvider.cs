using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.CloudStorage
{
    public class CloudStoragePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            context.AddGroup(CloudStoragePermissions.GroupName, L("Permission:CloudStorage"))
                .AddPermission(CloudStoragePermissions.CloudStorage.Uploads, L("Permission:Uploads"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpCloudStorageResource>(name);
        }
    }
}
