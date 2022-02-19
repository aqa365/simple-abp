using System.Threading.Tasks;

namespace Simple.Abp.AntdTheme
{
    public interface IAntdThemeSettingsAppService
    {
        Task<AntdThemeSettingsDto> GetAsync();

        Task UpdateAsync(AntdThemeSettingsDto input);
    }
}
