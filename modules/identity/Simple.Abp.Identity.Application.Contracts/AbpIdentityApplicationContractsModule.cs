﻿using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Simple.Abp.Identity
{
    [DependsOn(
		typeof(AbpIdentityDomainSharedModule),
		typeof(AbpUsersAbstractionModule),
		typeof(AbpAuthorizationModule),
		typeof(AbpDddApplicationModule),
		typeof(AbpPermissionManagementApplicationContractsModule)
	)]
	public class AbpIdentityApplicationContractsModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpVirtualFileSystemOptions>(options => 
				options.FileSets.AddEmbedded<AbpIdentityApplicationContractsModule>());

			Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources.Get<IdentityResource>().AddBaseTypes(new Type[]
				{
					typeof(AbpValidationResource)
				}).AddVirtualJson("/Localization/ApplicationContracts");
			});

			Configure<AbpExceptionLocalizationOptions>(options => options.MapCodeNamespace("Simple.Abp.Identity", typeof(IdentityResource)));
		}

		public override void PostConfigureServices(ServiceConfigurationContext context)
		{
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("Identity", "User", new Type[]
			{
				typeof(IdentityUserDto)
			}, new Type[]
			{
				typeof(IdentityUserCreateDto)
			}, new Type[]
			{
				typeof(IdentityUserUpdateDto)
			});
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("Identity", "Role", new Type[]
			{
				typeof(IdentityRoleDto)
			}, new Type[]
			{
				typeof(IdentityRoleCreateDto)
			}, new Type[]
			{
				typeof(IdentityRoleUpdateDto)
			});
			ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi("Identity", "ClaimType", new Type[]
			{
				typeof(ClaimTypeDto)
			}, new Type[]
			{
				typeof(CreateClaimTypeDto)
			}, new Type[]
			{
				typeof(UpdateClaimTypeDto)
			});
		}
	}
}