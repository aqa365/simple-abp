namespace Simple.Abp.AntdTheme
{
    public class AntdThemeSettingsDto
    {
        public PageStyleSetting PageStyleSetting { get; set; }

        public ThemeColor ThemeColor { get; set; }

        public NavigationMode NavigationMode { get; set; }

        public RegionalSettings RegionalSettings { get; set; }

        public OtherSettings OtherSettings { get; set; }

        public AntdThemeSettingsDto()
        {
            PageStyleSetting = new PageStyleSetting();
            ThemeColor = new ThemeColor();
            NavigationMode = new NavigationMode();
            RegionalSettings = new RegionalSettings();
            OtherSettings = new OtherSettings();
        }

    }

    public class PageStyleSetting
    {
        public EnumAntdThemeStyle PageStyle { get; set; }
    }

    public class ThemeColor 
    {
        public string Color { get; set; }
    }

    public class NavigationMode
    {
        public EnumAntdThemeSlidMenuLayout SlidMenuLayout { get; set; }

        public EnumAntdThemeContentWidthStyle ContentWidth { get; set; }

        public bool FixedHeader { get; set; } = true;

        public bool FixedSidebar { get; set; } = true;

        public bool SplitMenus { get; set; }
    }

    public class RegionalSettings 
    {
        public bool Header { get; set; } = true;

        public bool Footer { get; set; } = true;

        public bool Menu { get; set; } = true;

        public bool MenuHeader { get; set; } = true;
    }

    public class OtherSettings
    {
        public bool WeakMode { get; set; }
    }
}
