using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.Test.Permission
{
    public class SimpleTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var group = context.AddGroup(SimpleTestPermissions.GroupName, L("Permission:Venom"));
            group.AddPermission(SimpleTestPermissions.Venom.Default, L("Permission:Configs"));

            group.AddPermission(SimpleTestPermissions.Venom.Aim, L("Permission:Aim"));
            group.AddPermission(SimpleTestPermissions.Venom.Rcs, L("Permission:Rcs"));
            group.AddPermission(SimpleTestPermissions.Venom.Radar, L("Permission:Radar"));
            group.AddPermission(SimpleTestPermissions.Venom.Trigger, L("Permission:Trigger"));
            group.AddPermission(SimpleTestPermissions.Venom.Sonar, L("Permission:Sonar"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AuditLoggingResource>(name);
        }
    }
}
