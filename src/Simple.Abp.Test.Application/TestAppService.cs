using Volo.Abp.Application.Services;

namespace Simple.Abp.Test
{
    public class TestAppService : ApplicationService, ITestAppService
    {
        public TestAppService()
        {
            //LocalizationResource = typeof();
        }

        public string Get()
        {
            string values = L["Menu:Tags"];
            return values;
        }
    }
}
