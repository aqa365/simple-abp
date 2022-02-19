namespace Simple.Abp.AntdTheme
{
    public class AntdThemeSettingsDto
    {
        public EnumAntdThemeStyle Style { get; set; }

        public EnumAntdThemeColor Color { get; set; }

        public EnumAntdThemeMenuStyle MenuStyle { get; set; }

        public EnumAntdThemeWidthStyle WidthStyle { get; set; }

        public bool FixedHeader { get; set; }

        public bool FixedLeftMenu { get; set; }
        
        public bool AutoCutMenu { get; set; }

        public bool Content { get; set; } = true;
        public bool Top { get; set; } = true;

        public bool Footer { get; set; } = true;

        public bool Menu { get; set; } = true;

        public bool MenuHeader { get; set; } = true;

        public bool ColorWeakMode { get; set; }
    }
}
