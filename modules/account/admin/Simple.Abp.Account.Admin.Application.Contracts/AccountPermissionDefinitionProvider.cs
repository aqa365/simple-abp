using Simple.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Simple.Abp.Account
{
    public class AccountPermissionDefinitionProvider : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			context.AddGroup(AccountPermissions.GroupName, L("Permission:Account"), MultiTenancySides.Both).AddPermission(AccountPermissions.SettingManagement, L("Permission:SettingManagement"), MultiTenancySides.Both);
		}

		private static LocalizableString L(string name)
		{
			return LocalizableString.Create<AccountResource>(name);
		}
	}
}
