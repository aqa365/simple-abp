using Volo.Abp.Reflection;

namespace Simple.Abp.Account
{
    public static class AccountPermissions
	{
		public static string[] GetAll()
		{
			return ReflectionHelper.GetPublicConstantsRecursively(typeof(AccountPermissions));
		}

		public const string GroupName = "AbpAccount";

		public const string SettingManagement = "AbpAccount.SettingManagement";
	}
}
