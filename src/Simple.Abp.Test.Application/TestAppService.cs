using Simple.Abp.Articles;
using Simple.Abp.IdentityServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.IdentityServer.Localization;

namespace Simple.Abp.Test
{
    public class TestAppService : ApplicationService, ITestAppService
    {
        public TestAppService()
        {
            LocalizationResource = typeof(ArticlesResource);
        }

        public string Get()
        {
            string values = L["Menu:Tags"];
            return values;
        }
    }
}
