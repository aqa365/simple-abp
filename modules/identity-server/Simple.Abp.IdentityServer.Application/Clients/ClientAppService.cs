using Microsoft.AspNetCore.Authorization;
using Simple.Abp.IdentityServer.Clients.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.Clients
{
    [Authorize(AbpIdentityServerPermissions.Client.Default)]
	public class ClientAppService : IdentityServerAppServiceBase,IClientAppService
	{
		protected IClientRepository ClientRepository { get; }

		public ClientAppService(IClientRepository clientRepository)
		{
			this.ClientRepository = clientRepository;
		}

		public virtual async Task<PagedResultDto<ClientWithDetailsDto>> GetListAsync(GetClientListInput input)
		{
			var clients = await this.ClientRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
			var count = await this.ClientRepository.GetCountAsync();
			List<ClientWithDetailsDto> list = base.ObjectMapper.Map<List<Client>, List<ClientWithDetailsDto>>(clients);
			return new PagedResultDto<ClientWithDetailsDto>(count, list);
		}

		public virtual async Task<ClientWithDetailsDto> GetAsync(Guid id)
		{
			var client = await this.ClientRepository.GetAsync(id);
			return base.ObjectMapper.Map<Client, ClientWithDetailsDto>(client);
		}

		[Authorize(AbpIdentityServerPermissions.Client.Create)]
		public virtual async Task<ClientWithDetailsDto> CreateAsync(CreateClientDto input)
		{
			await this.CheckClientIdExistAsync(input.ClientId);
			var client = new Client(base.GuidGenerator.Create(), input.ClientId)
			{
				ClientName = input.ClientName,
				Description = input.Description,
				ClientUri = input.ClientUri,
				LogoUri = input.LogoUri,
				RequireConsent = input.RequireConsent
			};
			foreach (var clientSecretDto in input.Secrets)
			{
				clientSecretDto.Value = IdentityServer4.Models.HashExtensions.Sha256(clientSecretDto.Value);
				client.AddSecret(clientSecretDto.Value, clientSecretDto.Expiration, clientSecretDto.Type, clientSecretDto.Description);
			}
			string[] scopes = input.Scopes;
			for (int i = 0; i < scopes.Length; i++)
			{
				client.AddScope(scopes[i]);
			}
			HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo<CreateClientDto, Client>(input, client);
			var result = await this.ClientRepository.InsertAsync(client);
			return base.ObjectMapper.Map<Client, ClientWithDetailsDto>(result);
		}

		[Authorize(AbpIdentityServerPermissions.Client.Update)]
		public virtual async Task<ClientWithDetailsDto> UpdateAsync(Guid id, UpdateClientDto input)
		{
			var client = await this.ClientRepository.GetAsync(id);
			client.ClientName = input.ClientName;
			client.Description = input.Description;
			client.ClientUri = input.ClientUri;
			client.LogoUri = input.LogoUri;
			client.Enabled = input.Enabled;
			client.RequireConsent = input.RequireConsent;
			client.AccessTokenLifetime = input.AccessTokenLifetime;
			client.ConsentLifetime = input.ConsentLifetime;
			client.AccessTokenType = input.AccessTokenType;
			client.EnableLocalLogin = input.EnableLocalLogin;
			client.IncludeJwtId = input.IncludeJwtId;
			client.AllowOfflineAccess = input.AllowOfflineAccess;
			client.AlwaysSendClientClaims = input.AlwaysSendClientClaims;
			client.PairWiseSubjectSalt = input.PairWiseSubjectSalt;
			client.UserSsoLifetime = input.UserSsoLifetime;
			client.UserCodeType = input.UserCodeType;
			client.DeviceCodeLifetime = input.DeviceCodeLifetime;
			client.AllowRememberConsent = input.AllowRememberConsent;
			client.RequirePkce = input.RequirePkce;
			client.RequireClientSecret = input.RequireClientSecret;
			this.UpdateClientSecrets(input, client);
			this.UpdateClientClaims(input, client);
			this.UpdateClientProperties(input, client);
			this.UpdateClientRedirectUris(input, client);
			this.UpdateClientPostLogoutRedirectUris(input, client);
			this.UpdateClientCorsOrigins(input, client);
			this.UpdateClientGrantTypes(input, client);
			this.UpdateClientIdentityProviderRestrictions(input, client);
			this.UpdateClientScopes(input, client);
			HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo<UpdateClientDto, Client>(input, client);
			var result = await this.ClientRepository.UpdateAsync(client);
			return base.ObjectMapper.Map<Client, ClientWithDetailsDto>(result);
		}

		[Authorize(AbpIdentityServerPermissions.Client.Delete)]
		public virtual async Task DeleteAsync(Guid id)
		{
			await this.ClientRepository.DeleteAsync(id);
		}

		protected virtual void UpdateClientSecrets(UpdateClientDto input, Client client)
		{
			foreach (var clientSecretDto in input.ClientSecrets)
			{
				if (client.FindSecret(clientSecretDto.Value, clientSecretDto.Type) == null)
				{
					clientSecretDto.Value = IdentityServer4.Models.HashExtensions.Sha256(clientSecretDto.Value);
					client.AddSecret(clientSecretDto.Value, clientSecretDto.Expiration, clientSecretDto.Type, clientSecretDto.Description);
				}
			}
			var list = client.ClientSecrets.ToList<ClientSecret>();
			foreach(var clientSecret in list)
            {
				if (input.ClientSecrets.FirstOrDefault((ClientSecretDto s) => clientSecret.Equals(client.Id, s.Value, s.Type)) == null)
				{
					client.RemoveSecret(clientSecret.Value, clientSecret.Type);
				}
			}
		}

		protected virtual void UpdateClientProperties(UpdateClientDto input, Client client)
		{
			foreach (var clientPropertyDto in input.Properties)
			{
				if (client.FindProperty(clientPropertyDto.Key) == null)
				{
					client.AddProperty(clientPropertyDto.Key, clientPropertyDto.Value);
				}
			}
			var list = client.Properties.ToList<ClientProperty>();
			foreach(var property in list)
            {
				if (input.Properties.FirstOrDefault((ClientPropertyDto p) => property.Equals(client.Id, p.Key, p.Value)) == null)
				{
					client.RemoveProperty(property.Key);
				}
			}
		}

		protected virtual void UpdateClientClaims(UpdateClientDto input, Client client)
		{
			foreach (var clientClaimDto in input.Claims)
			{
				if (client.FindClaim(clientClaimDto.Value, clientClaimDto.Type) == null)
				{
					client.AddClaim(clientClaimDto.Value, clientClaimDto.Type);
				}
			}
			var list = client.Claims.ToList<ClientClaim>();
			foreach(var claim in list)
            {
				if (input.Claims.FirstOrDefault((ClientClaimDto c) => claim.Equals(client.Id, c.Value, c.Type)) == null)
				{
					client.RemoveClaim(claim.Value, claim.Type);
				}
			}
		}

		protected virtual void UpdateClientRedirectUris(UpdateClientDto input, Client client)
		{
			foreach (string text in input.RedirectUris)
			{
				if (client.FindRedirectUri(text) == null)
				{
					client.AddRedirectUri(text);
				}
			}
			var list = client.RedirectUris.ToList<ClientRedirectUri>();
			foreach(var redirectUri in list)
            {
				if (!input.RedirectUris.Any((string uri) => redirectUri.Equals(client.Id, uri)))
				{
					client.RemoveRedirectUri(redirectUri.RedirectUri);
				}
			}
		}

		protected virtual void UpdateClientCorsOrigins(UpdateClientDto input, Client client)
		{
			foreach (string text in input.AllowedCorsOrigins)
			{
				if (client.FindCorsOrigin(text) == null)
				{
					client.AddCorsOrigin(text);
				}
			}
			var list = client.AllowedCorsOrigins.ToList<ClientCorsOrigin>();
			foreach(var corsOrigin in list)
            {
				if (!input.AllowedCorsOrigins.Any((string uri) => corsOrigin.Equals(client.Id, uri)))
				{
					client.RemoveCorsOrigin(corsOrigin.Origin);
				}
			}
		}

		protected virtual void UpdateClientPostLogoutRedirectUris(UpdateClientDto input, Client client)
		{
			foreach (string text in input.PostLogoutRedirectUris)
			{
				if (client.FindPostLogoutRedirectUri(text) == null)
				{
					client.AddPostLogoutRedirectUri(text);
				}
			}
			var list = client.PostLogoutRedirectUris.ToList<ClientPostLogoutRedirectUri>();
			foreach(var postLogoutRedirectUri in list)
            {
				if (!input.PostLogoutRedirectUris.Any((string uri) => postLogoutRedirectUri.Equals(client.Id, uri)))
				{
					client.RemovePostLogoutRedirectUri(postLogoutRedirectUri.PostLogoutRedirectUri);
				}
			}
		}

		protected virtual void UpdateClientIdentityProviderRestrictions(UpdateClientDto input, Client client)
		{
			foreach (string text in input.IdentityProviderRestrictions)
			{
				if (client.FindIdentityProviderRestriction(text) == null)
				{
					client.AddIdentityProviderRestriction(text);
				}
			}
			var list = client.IdentityProviderRestrictions.ToList<ClientIdPRestriction>();
			foreach(var idPRestriction in list)
            {
				if (!input.IdentityProviderRestrictions.Any((string p) => idPRestriction.Equals(client.Id, p)))
				{
					client.RemoveIdentityProviderRestriction(idPRestriction.Provider);
				}
			}
		}

		protected virtual void UpdateClientGrantTypes(UpdateClientDto input, Client client)
		{
			foreach (string text in input.AllowedGrantTypes)
			{
				if (client.FindGrantType(text) == null)
				{
					client.AddGrantType(text);
				}
			}
			var list = client.AllowedGrantTypes.ToList<ClientGrantType>();
			foreach(var grantType in list)
            {
				if (!input.AllowedGrantTypes.Any((string g) => grantType.Equals(client.Id, g)))
				{
					client.RemoveGrantType(grantType.GrantType);
				}
			}
		}

		protected virtual void UpdateClientScopes(UpdateClientDto input, Client client)
		{
			foreach (string text in input.Scopes)
			{
				if (client.FindScope(text) == null)
				{
					client.AddScope(text);
				}
			}
			var list = client.AllowedScopes.ToList<ClientScope>();
			foreach(var scope in list)
            {
				if (!input.Scopes.Any((string s) => scope.Equals(client.Id, s)))
				{
					client.RemoveScope(scope.Scope);
				}
			}
		}

		protected virtual async Task CheckClientIdExistAsync(string clientId)
		{
			var flag = await this.ClientRepository.CheckClientIdExistAsync(clientId);
			if (flag)
			{
				throw new BusinessException("Volo.IdentityServer:DuplicateClientId").WithData("ClientId", clientId);
			}
		}
	}
}
