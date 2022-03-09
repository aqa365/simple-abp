using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Simple.Abp.AntdTheme
{
    public class AccountSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(N(nameof(PageStyleSetting.PageStyle)), "3", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(ThemeColor.Color)), "1", isVisibleToClients: true));

            context.Add(new SettingDefinition(N(nameof(NavigationMode.SlidMenuLayout)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(NavigationMode.ContentWidth)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(NavigationMode.FixedHeader)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(NavigationMode.FixedSidebar)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(NavigationMode.SplitMenus)), "false", isVisibleToClients: true));

            context.Add(new SettingDefinition(N(nameof(RegionalSettings.Header)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(RegionalSettings.Footer)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(RegionalSettings.Menu)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(RegionalSettings.MenuHeader)), "false", isVisibleToClients: true));

            context.Add(new SettingDefinition(N(nameof(OtherSettings.WeakMode)), "false", isVisibleToClients: true));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AntdThemeResource>(name);
        }
        private static string N(string name)
        {
            return $"Abp.AntdTheme.{name}";
        }
    }
}