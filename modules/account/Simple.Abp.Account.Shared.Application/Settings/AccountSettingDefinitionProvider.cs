using Simple.Abp.Account.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Simple.Abp.Account.Settings
{
	public class AccountSettingDefinitionProvider : SettingDefinitionProvider
	{
		public override void Define(ISettingDefinitionContext context)
		{
			context.Add(new SettingDefinition[]
			{
				new SettingDefinition("Abp.Account.IsSelfRegistrationEnabled", "true", L("DisplayName:IsSelfRegistrationEnabled"), L("Description:IsSelfRegistrationEnabled"), true),
				new SettingDefinition("Abp.Account.EnableLocalLogin", "true", L("DisplayName:EnableLocalLogin"), L("Description:EnableLocalLogin"), true),
				new SettingDefinition("Abp.Account.TwoFactorLogin.IsRememberBrowserEnabled", "true", L("DisplayName:IsRememberBrowserEnabled"), null, true)
			});
		}

		private static LocalizableString L(string name)
		{
			return LocalizableString.Create<AccountResource>(name);
		}
	}
}
