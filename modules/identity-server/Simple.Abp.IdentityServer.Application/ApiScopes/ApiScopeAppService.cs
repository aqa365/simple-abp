using Simple.Abp.IdentityServer.ApiScopes.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.ApiScopes
{
    public class ApiScopeAppService : IdentityServerAppServiceBase,IApiScopeAppService
    {
        private IApiScopeRepository _apiScopeRepository;

        public ApiScopeAppService(IApiScopeRepository apiScopeRepository)
        {
            _apiScopeRepository = apiScopeRepository;
        }

        public async Task<PagedResultDto<ApiScopeDto>> GetListAsync(GetApiScopeListInput input)
        {
            var apiScopeList = await _apiScopeRepository.GetListAsync(
                input.Sorting, input.SkipCount, input.MaxResultCount, input.Filter
            );

            var count = await _apiScopeRepository.GetCountAsync(input.Filter);
            var modelList = ObjectMapper.Map<List<ApiScope>, List<ApiScopeDto>>(apiScopeList);

            return new PagedResultDto<ApiScopeDto>(count, modelList);
        }

        public async Task<List<ApiScopeDto>> GetAllListAsync()
        {
            var apiScopeList = await _apiScopeRepository.GetListAsync();
            return ObjectMapper.Map<List<ApiScope>, List<ApiScopeDto>>(apiScopeList);
        }

        public async Task<ApiScopeDto> GetAsync(Guid id)
        {
            var apiScope = await _apiScopeRepository.GetAsync(id);
            return base.ObjectMapper.Map<ApiScope, ApiScopeDto>(apiScope);
        }

        public async Task<ApiScopeDto> CreateAsync(CreateApiScopeDto input)
        {
            var nameExist = await _apiScopeRepository.CheckNameExistAsync(input.Name);
            if (nameExist)
                throw new BusinessException("Volo.IdentityServer:DuplicateApiScopeName").WithData("Name", input.Name);

            var id = GuidGenerator.Create();
            var apiScope = new ApiScope(
                id, input.Name, input.DisplayName, input.Description,
                input.Required,
                input.Emphasize,
                input.ShowInDiscoveryDocument,
                input.Enabled
            );

            input.UserClaims?.ForEach(
                claim => apiScope.AddUserClaim(claim.Type)
            );

            HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo(input, apiScope);
            var result = await _apiScopeRepository.InsertAsync(apiScope);
            return ObjectMapper.Map<ApiScope, ApiScopeDto>(result);
        }

        public async Task<ApiScopeDto> UpdateAsync(Guid id, UpdateApiScopeDto input)
        {
            var apiScope = await _apiScopeRepository.GetAsync(id);
            apiScope.DisplayName = input.DisplayName;
            apiScope.Description = input.Description;
            apiScope.Required = input.Required;
            apiScope.Emphasize = input.Emphasize;
            apiScope.ShowInDiscoveryDocument = input.Enabled;
            apiScope.Enabled = input.Enabled;

            this.UpdateApiClaims(input, apiScope);

            apiScope.RemoveAllProperties();
            foreach (var item in input.Properties)
                apiScope.AddProperty(item.Key, item.Value);

            HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo(input, apiScope);

            var result = await _apiScopeRepository.UpdateAsync(apiScope);
            return base.ObjectMapper.Map<ApiScope, ApiScopeDto>(result);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _apiScopeRepository.DeleteAsync(id);
        }

        protected virtual void UpdateApiClaims(UpdateApiScopeDto input, ApiScope apiScope)
        {
            foreach (var claim in input.UserClaims)
                if (apiScope.FindClaim(claim.Type) == null)
                    apiScope.AddUserClaim(claim.Type);

            foreach (var claim in apiScope.UserClaims)
                if (input.UserClaims.FirstOrDefault(c => claim.Equals(apiScope.Id, c.Type)) == null)
                    apiScope.RemoveClaim(claim.Type);
        }
    }
}
