using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Simple.Abp.AntdTheme
{
    public class AntdThemePermissionDefinitionProvider : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var abpIdentity = context.AddGroup(AntdThemePermissions.GroupName, L("Permission:AntdThemeManagement"));
			abpIdentity.AddPermission(AntdThemePermissions.SettingManagement, L("Permission:SettingManagement"));
		}

		private static LocalizableString L(string name)
		{
			return LocalizableString.Create<AntdThemeResource>(name);
		}
	}
}
