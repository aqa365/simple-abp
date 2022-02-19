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

            return settingValue.To<T>();
        }

        public async Task<AntdThemeSettingsDto> GetAsync()
        {
            var currentSettingValues = await _settingManager.GetAllForCurrentUserAsync();

            var antdThemeSettingsDto = new AntdThemeSettingsDto();
            antdThemeSettingsDto.Style = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Style), EnumAntdThemeStyle.DarkMenu);
            antdThemeSettingsDto.Color = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Color), EnumAntdThemeColor.Lightblue);
            antdThemeSettingsDto.MenuStyle = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.MenuStyle), EnumAntdThemeMenuStyle.Left);
            antdThemeSettingsDto.WidthStyle = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.WidthStyle), EnumAntdThemeWidthStyle.Default);
            antdThemeSettingsDto.FixedHeader = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.FixedHeader), true);
            antdThemeSettingsDto.FixedLeftMenu = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.FixedLeftMenu), true);
            antdThemeSettingsDto.AutoCutMenu = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.AutoCutMenu), false);
            antdThemeSettingsDto.Content = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Content), true);
            antdThemeSettingsDto.Top = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Top), true);
            antdThemeSettingsDto.Footer = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Footer), true);
            antdThemeSettingsDto.Menu = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.Menu), true);
            antdThemeSettingsDto.MenuHeader = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.MenuHeader), true);
            antdThemeSettingsDto.ColorWeakMode = this.Get(currentSettingValues, nameof(AntdThemeSettingsDto.ColorWeakMode), true);

            return antdThemeSettingsDto;
        }

        public async Task UpdateAsync(AntdThemeSettingsDto input)
        {
            if (input == null)
                return;

            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Style)), ((int)input.Style).ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Color)), input.Color.To<int>().ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.MenuStyle)), input.MenuStyle.To<int>().ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.WidthStyle)), input.WidthStyle.To<int>().ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.FixedHeader)), input.FixedHeader.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.FixedLeftMenu)), input.FixedLeftMenu.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.AutoCutMenu)), input.AutoCutMenu.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Content)), input.Content.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Top)), input.Top.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Footer)), input.Footer.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.Menu)), input.Menu.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.MenuHeader)), input.MenuHeader.ToString());
            await _settingManager.SetForCurrentUserAsync(GetName(nameof(AntdThemeSettingsDto.ColorWeakMode)), input.ColorWeakMode.ToString());
        }
    }
}
