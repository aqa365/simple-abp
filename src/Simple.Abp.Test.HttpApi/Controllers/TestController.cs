using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Test.Controllers
{
    [RemoteService]
    [Area("Test")]
    [ControllerName("Test")]
    [Route("api/test")]
    public class TestController : AbpController, ITestAppService
    {
        private ITestAppService _testAppService;
        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }


        [HttpGet]
        public string Get()
        {
            return _testAppService.Get();
        }
    }
}
