using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;

namespace Simple.Abp.Test
{
    public class TestAppService : ApplicationService, ITestAppService
    {
        public string Get()
        {
            return this.ToString();
        }
    }
}
