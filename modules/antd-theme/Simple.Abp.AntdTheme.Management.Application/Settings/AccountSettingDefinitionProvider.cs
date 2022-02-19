using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace Simple.Abp.AntdTheme
{
    public class AccountSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Style)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Color)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.MenuStyle)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.WidthStyle)), "1", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.FixedHeader)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.FixedLeftMenu)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.AutoCutMenu)), "false", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Content)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Top)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Footer)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.Menu)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.MenuHeader)), "true", isVisibleToClients: true));
            context.Add(new SettingDefinition(N(nameof(AntdThemeSettingsDto.ColorWeakMode)), "true", isVisibleToClients: true));
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