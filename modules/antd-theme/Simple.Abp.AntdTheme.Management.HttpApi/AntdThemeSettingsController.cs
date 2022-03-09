using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.AntdTheme
{
    [RemoteService]
    [Area("AntdTheme")]
    [ControllerName("Settings")]
    [Route("api/antd-theme/settings")]
    public class AntdThemeSettingsController : AbpController, IAntdThemeSettingsAppService
    {

        private IAntdThemeSettingsAppService _antdThemeSettingsAppService;

        public AntdThemeSettingsController(IAntdThemeSettingsAppService antdThemeSettingsAppService)
        {
            _antdThemeSettingsAppService = antdThemeSettingsAppService;
        }

        [HttpGet]
        public Task<AntdThemeSettingsDto> GetAsync()
        {
            return _antdThemeSettingsAppService.GetAsync();
        }

        [HttpPut]
        public Task UpdateAsync(AntdThemeSettingsDto input)
        {
           return _antdThemeSettingsAppService.UpdateAsync(input);
        }
    }
}
