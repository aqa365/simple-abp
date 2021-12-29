using Microsoft.AspNetCore.Mvc;
using Simple.Abp.IdentityServer.ApiScopes;
using Simple.Abp.IdentityServer.ApiScopes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;

namespace Simple.Abp.IdentityServer
{
    [Controller]
    [ControllerName("ApiScopes")]
    [Route("api/identity-server/api-scopes")]
    [RemoteService(true, Name = IdentityServerRemoteServiceConsts.RemoteServiceName)]
    [Area("identityServer")]
    public class ApiScopeController : AbpController, IApiScopeAppService, IRemoteService, IApplicationService
    {
        private readonly IApiScopeAppService _apiScopeAppService;

        public ApiScopeController(IApiScopeAppService apiScopeAppService)
        {
            _apiScopeAppService = apiScopeAppService;
        }

        [Route("")]
        [HttpGet]
        public Task<PagedResultDto<ApiScopeDto>> GetListAsync(GetApiScopeListInput input)
        {
            return _apiScopeAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("all")]
        public Task<List<ApiScopeDto>> GetAllListAsync()
        {
            return _apiScopeAppService.GetAllListAsync();
        }

        [Route("{id}")]
        [HttpGet]
        public Task<ApiScopeDto> GetAsync(Guid id)
        {
            return _apiScopeAppService.GetAsync(id);
        }

        [HttpPost]
        public Task<ApiScopeDto> CreateAsync(CreateApiScopeDto input)
        {
            return _apiScopeAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ApiScopeDto> UpdateAsync(Guid id, UpdateApiScopeDto input)
        {
           return _apiScopeAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
           return _apiScopeAppService.DeleteAsync(id);
        }
    }
}
