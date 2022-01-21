using Microsoft.AspNetCore.Authorization;
using Simple.Abp.IdentityServer.IdentityResources.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.IdentityResources
{
    [Authorize(AbpIdentityServerPermissions.IdentityResource.Default)]
	public class IdentityResourceAppService : IdentityServerAppServiceBase, IIdentityResourceAppService
	{
		protected IIdentityResourceDataSeeder IdentityResourceDataSeeder { get; }

		protected IIdentityResourceRepository IdentityResourceRepository { get; }

		public IdentityResourceAppService(IIdentityResourceRepository identityResourceRepository, IIdentityResourceDataSeeder identityResourceDataSeeder)
		{
			this.IdentityResourceRepository = identityResourceRepository;
			this.IdentityResourceDataSeeder = identityResourceDataSeeder;
		}

		public virtual async Task<PagedResultDto<IdentityResourceWithDetailsDto>> GetListAsync(GetIdentityResourceListInput input)
		{
			var identityResources = await this.IdentityResourceRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
			var count = await this.IdentityResourceRepository.GetCountAsync();
			List<IdentityResourceWithDetailsDto> list = base.ObjectMapper.Map<List<IdentityResource>, List<IdentityResourceWithDetailsDto>>(identityResources);
			return new PagedResultDto<IdentityResourceWithDetailsDto>(count, list);
		}

		public virtual async Task<List<IdentityResourceWithDetailsDto>> GetAllListAsync()
		{
			var list = await this.IdentityResourceRepository.GetListAsync();
			return ObjectMapper.Map<List<IdentityResource>, List<IdentityResourceWithDetailsDto>>(list);
		}

		public virtual async Task<IdentityResourceWithDetailsDto> GetAsync(Guid id)
		{
			var identityResource = await this.IdentityResourceRepository.GetAsync(id);
			return ObjectMapper.Map<IdentityResource, IdentityResourceWithDetailsDto>(identityResource);
		}

		[Authorize(AbpIdentityServerPermissions.IdentityResource.Create)]
		public virtual async Task<IdentityResourceWithDetailsDto> CreateAsync(CreateIdentityResourceDto input)
		{
			var nameExist = await this.IdentityResourceRepository.CheckNameExistAsync(input.Name);
			if (nameExist)
				throw new BusinessException("Volo.IdentityServer:DuplicateIdentityResourceName").WithData("Name", input.Name);

			var identityResource = new IdentityResource(
				base.GuidGenerator.Create(),
				input.Name, input.DisplayName, input.Description, input.Enabled,
				input.Required, input.Emphasize, input.ShowInDiscoveryDocument
			);

            foreach (var item in input.UserClaims)
				identityResource.AddUserClaim(item.Type);

			HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo<CreateIdentityResourceDto, IdentityResource>(input, identityResource);
			var result = await this.IdentityResourceRepository.InsertAsync(identityResource);

			identityResource = result;
			return base.ObjectMapper.Map<IdentityResource, IdentityResourceWithDetailsDto>(identityResource);
		}

		[Authorize(AbpIdentityServerPermissions.IdentityResource.Update)]
		public virtual async Task<IdentityResourceWithDetailsDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input)
		{
			var flag = await this.IdentityResourceRepository.CheckNameExistAsync(input.Name, new Guid?(id));
			if (flag)
			{
				throw new BusinessException("Volo.IdentityServer:DuplicateIdentityResourceName").WithData("Name", input.Name);
			}
			var identityResource = await this.IdentityResourceRepository.GetAsync(id);
			identityResource.Name = input.Name;
			identityResource.DisplayName = input.DisplayName;
			identityResource.Description = input.Description;
			identityResource.Enabled = input.Enabled;
			identityResource.Required = input.Required;
			identityResource.Emphasize = input.Emphasize;
			identityResource.ShowInDiscoveryDocument = input.ShowInDiscoveryDocument;

			this.UpdateIdentityClaims(input, identityResource);

			identityResource.RemoveAllProperties();
			foreach (var item in input.Properties)
				identityResource.AddProperty(item.Key, item.Value);

			HasExtraPropertiesObjectExtendingExtensions.MapExtraPropertiesTo<UpdateIdentityResourceDto, IdentityResource>(input, identityResource);
			identityResource = await this.IdentityResourceRepository.UpdateAsync(identityResource);
			return base.ObjectMapper.Map<IdentityResource, IdentityResourceWithDetailsDto>(identityResource);
		}

		[Authorize(AbpIdentityServerPermissions.IdentityResource.Default)]
		public virtual async Task DeleteAsync(Guid id)
		{
			await this.IdentityResourceRepository.DeleteAsync(id);
		}

		[Authorize(AbpIdentityServerPermissions.IdentityResource.Create)]
		public virtual async Task CreateStandardResourcesAsync()
		{
			await this.IdentityResourceDataSeeder.CreateStandardResourcesAsync();
		}

		protected virtual void UpdateIdentityClaims(UpdateIdentityResourceDto input,IdentityResource identityResource)
		{
			foreach (var claim in input.UserClaims)
				if (identityResource.FindUserClaim(claim.Type) == null)
					identityResource.AddUserClaim(claim.Type);

			foreach (var identityClaim in identityResource.UserClaims)
				if (!input.UserClaims.Any(c => identityClaim.Equals(identityResource.Id, c.Type)))
					identityResource.RemoveUserClaim(identityClaim.Type);
		}
	}
}
