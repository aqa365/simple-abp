using Microsoft.AspNetCore.Authorization;
using Simple.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.ApiResources
{
    [Authorize(AbpIdentityServerPermissions.ApiResource.Default)]
    public class ApiResourceAppService : IdentityServerAppServiceBase, IRemoteService, IApplicationService, IApiResourceAppService
    {
        private IApiResourceRepository _apiResourceRepository;

        public ApiResourceAppService(IApiResourceRepository apiResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
        }

        public virtual async Task<PagedResultDto<ApiResourceWithDetailsDto>> GetListAsync(GetApiResourceListInput input)
        {
            var resources = await _apiResourceRepository.GetListAsync(
                input.Sorting, input.SkipCount, input.MaxResultCount, input.Filter
            );

            var count = await _apiResourceRepository.GetCountAsync(input.Filter);
            var list = base.ObjectMapper.Map<List<ApiResource>, List<ApiResourceWithDetailsDto>>(resources);

            return new PagedResultDto<ApiResourceWithDetailsDto>(count, list);
        }

        public virtual async Task<List<ApiResourceWithDetailsDto>> GetAllListAsync()
        {
            var list = await _apiResourceRepository.GetListAsync();
            return base.ObjectMapper.Map<List<ApiResource>, List<ApiResourceWithDetailsDto>>(list);
        }

        public virtual async Task<ApiResourceWithDetailsDto> GetAsync(Guid id)
        {
            var apiResource = await _apiResourceRepository.GetAsync(id);
            return base.ObjectMapper.Map<ApiResource, ApiResourceWithDetailsDto>(apiResource);
        }

        [Authorize(AbpIdentityServerPermissions.ApiResource.Create)]
        public virtual async Task<ApiResourceWithDetailsDto> CreateAsync(CreateApiResourceDto input)
        {
            var nameExist = await _apiResourceRepository.CheckNameExistAsync(input.Name);
            if (nameExist)
                throw new BusinessException("Volo.IdentityServer:DuplicateApiResourceName").WithData("Name", input.Name);

            var id = GuidGenerator.Create();
            var apiResource = new ApiResource(id, input.Name, input.DisplayName, input.Description);
            apiResource.ShowInDiscoveryDocument = input.ShowInDiscoveryDocument;

            foreach (var claim in input.UserClaims)
                apiResource.AddUserClaim(claim.Type);

            HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo(input, apiResource);
            var result = await _apiResourceRepository.InsertAsync(apiResource);
            return base.ObjectMapper.Map<ApiResource, ApiResourceWithDetailsDto>(result);
        }

        [Authorize(AbpIdentityServerPermissions.ApiResource.Update)]
        public virtual async Task<ApiResourceWithDetailsDto> UpdateAsync(Guid id, UpdateApiResourceDto input)
        {
            var apiResource = await _apiResourceRepository.GetAsync(id);
            apiResource.DisplayName = input.DisplayName;
            apiResource.Description = input.Description;
            apiResource.Enabled = input.Enabled;
            apiResource.ShowInDiscoveryDocument = input.ShowInDiscoveryDocument;
          
            this.UpdateApiScope(input, apiResource);
            this.UpdateApiSecrets(input, apiResource);
            this.UpdateApiClaims(input, apiResource);

            apiResource.RemoveAllProperties();
            foreach (var item in input.Properties)
                apiResource.AddProperty(item.Key, item.Value);

            HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo(input, apiResource);

            var result = await _apiResourceRepository.UpdateAsync(apiResource);
            return base.ObjectMapper.Map<ApiResource, ApiResourceWithDetailsDto>(result);
        }

        [Authorize(AbpIdentityServerPermissions.ApiResource.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _apiResourceRepository.DeleteAsync(id);
        }

        protected virtual void UpdateApiScope(UpdateApiResourceDto input, ApiResource apiResource)
        {
            foreach (ApiResourceScopeDto apiResourceScopeDto in input.Scopes)
                if (apiResource.FindScope(apiResourceScopeDto.Scope) == null)
                    apiResource.AddScope(apiResourceScopeDto.Scope);

            foreach (var scope in apiResource.Scopes)
                if (!input.Scopes.Any(c => scope.Equals(apiResource.Id, c.Scope)))
                    apiResource.RemoveScope(scope.Scope);
        }

        protected virtual void UpdateApiSecrets(UpdateApiResourceDto input, ApiResource apiResource)
        {
            foreach (var apiSecretDto in input.Secrets)
                if (apiResource.FindSecret(apiSecretDto.Value, apiSecretDto.Type) == null)
                    apiResource.AddSecret(
                        apiSecretDto.Value = IdentityServer4.Models.HashExtensions.Sha256(apiSecretDto.Value),
                        apiSecretDto.Expiration, apiSecretDto.Type, apiSecretDto.Description
                    );

            foreach (var clientSecret in apiResource.Secrets)
                if (input.Secrets.FirstOrDefault(s => clientSecret.Equals(apiResource.Id, s.Value, s.Type)) == null)
                    apiResource.RemoveSecret(clientSecret.Value, clientSecret.Type);
        }

        protected virtual void UpdateApiClaims(UpdateApiResourceDto input, ApiResource apiResource)
        {
            foreach (var claim in input.UserClaims)
                if (apiResource.FindClaim(claim.Type) == null)
                    apiResource.AddUserClaim(claim.Type);

            foreach (var claim in apiResource.UserClaims)
                if (input.UserClaims.FirstOrDefault(c => claim.Equals(apiResource.Id, c.Type)) == null)
                    apiResource.RemoveClaim(claim.Type);
        }
    }
}
