using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.AntdTheme
{
    [RemoteService]
    [Area("AntdTheme")]
    [ControllerName("AntdThemeManagement")]
    [Route("api/antd-theme/management")]
    public class AntdThemeController : AbpController, IAntdThemeSettingsAppService
    {

        private IAntdThemeSettingsAppService _antdThemeSettingsAppService;

        public AntdThemeController(IAntdThemeSettingsAppService antdThemeSettingsAppService)
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
