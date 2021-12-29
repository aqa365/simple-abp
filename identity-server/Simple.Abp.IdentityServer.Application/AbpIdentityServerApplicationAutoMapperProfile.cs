using AutoMapper;
using Volo.Abp.Identity;
using Simple.Abp.IdentityServer.ApiResources.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using Simple.Abp.IdentityServer.ClaimTypes.Dtos;
using Simple.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp.IdentityServer.Clients;
using Simple.Abp.IdentityServer.IdentityResources.Dtos;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Simple.Abp.IdentityServer.ApiScopes.Dtos;

namespace Simple.Abp.IdentityServer
{
	public class AbpIdentityServerApplicationAutoMapperProfile : Profile
	{
		public AbpIdentityServerApplicationAutoMapperProfile()
		{
			// ApiResource
			base.CreateMap<ApiResourceScope, ApiResourceScopeDto>();	
			base.CreateMap<ApiResourceSecret, ApiResourceSecretDto>();
			base.CreateMap<ApiResourceClaim, ApiResourceClaimDto>();
			AbpAutoMapperExtensibleDtoExtensions.MapExtraProperties(base.CreateMap<ApiResource, ApiResourceWithDetailsDto>());

			// ApiScope
			base.CreateMap<ApiScopeClaim, ApiScopeClaimDto>();
			AbpAutoMapperExtensibleDtoExtensions.MapExtraProperties(base.CreateMap<ApiScope, ApiScopeDto>());

			AbpAutoMapperExtensibleDtoExtensions.MapExtraProperties(base.CreateMap<IdentityResource, IdentityResourceWithDetailsDto>());
			base.CreateMap<IdentityResourceClaim, IdentityResourceClaimDto>();
	
			AbpAutoMapperExtensibleDtoExtensions.MapExtraProperties(base.CreateMap<Client, ClientWithDetailsDto>());
			base.CreateMap<ClientSecret, ClientSecretDto>();
			base.CreateMap<ClientScope, ClientScopeDto>();
			base.CreateMap<ClientClaim, ClientClaimDto>();
			base.CreateMap<ClientProperty, ClientPropertyDto>();
			base.CreateMap<ClientRedirectUri, ClientRedirectUriDto>();
			base.CreateMap<ClientPostLogoutRedirectUri, ClientPostLogoutRedirectUriDto>();
			base.CreateMap<ClientIdPRestriction, ClientIdentityProviderRestrictionDto>();
			base.CreateMap<ClientGrantType, ClientGrantTypeDto>();
			base.CreateMap<ClientCorsOrigin, ClientCorsOriginDto>();
			AbpAutoMapperExtensibleDtoExtensions.MapExtraProperties(base.CreateMap<IdentityClaimType, IdentityClaimTypeDto>());
		}
	}
}
