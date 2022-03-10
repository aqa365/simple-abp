using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;

namespace Simple.Abp.AntdTheme
{
    [Authorize(AntdThemePermissions.SettingManagement)]
    public class AntdThemeSettingsAppService : ApplicationService, IAntdThemeSettingsAppService
    {
        protected ISettingManager _settingManager;

        public AntdThemeSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }
        private string GetName(string name)
        {
            return $"Abp.AntdTheme.{name}";

        }
        private T Get<T>(List<SettingValue> data, string name, T defaultValue = default(T)) where T : struct
        {
            var settingValue = data.FirstOrDefault(c => c.Name.Equals(GetName(name)));
            if (string.IsNullOrWhiteSpace(settingValue?.Value))
                return defaultValue;

            var type = typeof(T);
            if (type.IsEnum)
                return settingValue.Value.ToEnum<T>();

            return settingValue.Value.To<T>();
        }

        private string Get(List<SettingValue> data, string name,string value)
        {
            var settingValue = data.FirstOrDefault(c => c.Name.Equals(GetName(name)));
            return settingValue.Value ?? value;
        }



        public async Task<AntdThemeSettingsDto> GetAsync()
        {
            var currentSettingValues = await _settingManager.GetAllForCurrentUserAsync();

            var antdThemeSettingsDto = new AntdThemeSettingsDto();
            antdThemeSettingsDto.PageStyleSetting.PageStyle = this.Get(
                currentSettingValues, nameof(PageStyleSetting.PageStyle), EnumAntdThemeStyle.Dark
            );
            antdThemeSettingsDto.ThemeColor.Color = this.Get(
                currentSettingValues, nameof(ThemeColor.Color), "#2F54EB"
            );

            // NavigationMode
            antdThemeSettingsDto.NavigationMode.SlidMenuLayout = this.Get(
                currentSettingValues, nameof(NavigationMode.SlidMenuLayout), EnumAntdThemeSlidMenuLayout.Left
            );
            antdThemeSettingsDto.NavigationMode.ContentWidth = this.Get(
                currentSettingValues, nameof(NavigationMode.ContentWidth), EnumAntdThemeContentWidthStyle.Default
            );
            antdThemeSettingsDto.NavigationMode.FixedHeader = this.Get(
                currentSettingValues, nameof(NavigationMode.FixedHeader), true
            );
            antdThemeSettingsDto.NavigationMode.FixedSidebar = this.Get(
                currentSettingValues, nameof(NavigationMode.FixedSidebar), true
            );
            antdThemeSettingsDto.NavigationMode.SplitMenus = this.Get(
                currentSettingValues, nameof(NavigationMode.SplitMenus), false
            );

            // RegionalSettings
            antdThemeSettingsDto.RegionalSettings.Header = this.Get(
                currentSettingValues, nameof(RegionalSettings.Header), true
            );
            antdThemeSettingsDto.RegionalSettings.Footer = this.Get(
                currentSettingValues, nameof(RegionalSettings.Footer), true
            );
            antdThemeSettingsDto.RegionalSettings.Menu = this.Get(
                currentSettingValues, nameof(RegionalSettings.Menu), true
            );
            antdThemeSettingsDto.RegionalSettings.MenuHeader = this.Get(
                currentSettingValues, nameof(RegionalSettings.MenuHeader), false
            );

            // OtherSettings
            antdThemeSettingsDto.OtherSettings.WeakMode = this.Get(
                currentSettingValues, nameof(OtherSettings.WeakMode), false
            );

            return antdThemeSettingsDto;
        }

        public async Task UpdateAsync(AntdThemeSettingsDto input)
        {
            if (input == null)
                return;

            await _settingManager.SetForCurrentUserAsync(GetName(nameof(PageStyleSetting.PageStyle)), ((int)input.PageStyleSetting.PageStyle).ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(ThemeColor.Color)), input.ThemeColor.Color);

            await _settingManager.SetForCurrentUserAsync(GetName(nameof(NavigationMode.SlidMenuLayout)), input.NavigationMode.SlidMenuLayout.To<int>().ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(NavigationMode.ContentWidth)), input.NavigationMode.ContentWidth.To<int>().ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(NavigationMode.FixedHeader)), input.NavigationMode.FixedHeader.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(NavigationMode.FixedSidebar)), input.NavigationMode.FixedSidebar.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(NavigationMode.SplitMenus)), input.NavigationMode.SplitMenus.ToString());

            await _settingManager.SetForCurrentUserAsync(GetName(nameof(RegionalSettings.Header)), input.RegionalSettings.Header.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(RegionalSettings.Footer)), input.RegionalSettings.Footer.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(RegionalSettings.Menu)), input.RegionalSettings.Menu.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(RegionalSettings.MenuHeader)), input.RegionalSettings.MenuHeader.ToString());

            await _settingManager.SetForCurrentUserAsync(GetName(nameof(OtherSettings.WeakMode)), input.OtherSettings.WeakMode.ToString());
        }
    }
}
