using Volo.Abp.Authorization.Permissions;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Simple.Abp.IdentityServer
{
    public class AbpIdentityServerPermissionDefinitionProvider : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var identityServer = context.AddGroup(AbpIdentityServerPermissions.GroupName, L("Permission:IdentityServer"));
			var identityResource = identityServer.AddPermission(AbpIdentityServerPermissions.IdentityResource.Default, L("Permission:IdentityResources"), MultiTenancySides.Host);
			identityResource.AddChild(AbpIdentityServerPermissions.IdentityResource.Update, L("Permission:Edit"), MultiTenancySides.Host);
			identityResource.AddChild(AbpIdentityServerPermissions.IdentityResource.Delete, L("Permission:Delete"), MultiTenancySides.Host);
			identityResource.AddChild(AbpIdentityServerPermissions.IdentityResource.Create, L("Permission:Create"), MultiTenancySides.Host);
			identityResource.AddChild(AbpIdentityServerPermissions.IdentityResource.ViewChangeHistory, L("Permission:ViewChangeHistory"), MultiTenancySides.Host);
			var apiResource = identityServer.AddPermission(AbpIdentityServerPermissions.ApiResource.Default, L("Permission:ApiResources"), MultiTenancySides.Host);
			apiResource.AddChild(AbpIdentityServerPermissions.ApiResource.Update, L("Permission:Edit"), MultiTenancySides.Host);
			apiResource.AddChild(AbpIdentityServerPermissions.ApiResource.Delete, L("Permission:Delete"), MultiTenancySides.Host);
			apiResource.AddChild(AbpIdentityServerPermissions.ApiResource.Create, L("Permission:Create"), MultiTenancySides.Host);
			apiResource.AddChild(AbpIdentityServerPermissions.ApiResource.ViewChangeHistory, L("Permission:ViewChangeHistory"), MultiTenancySides.Host);
			var client = identityServer.AddPermission(AbpIdentityServerPermissions.Client.Default, L("Permission:Clients"), MultiTenancySides.Host);
			client.AddChild(AbpIdentityServerPermissions.Client.Update, L("Permission:Edit"), MultiTenancySides.Host);
			client.AddChild(AbpIdentityServerPermissions.Client.Delete, L("Permission:Delete"), MultiTenancySides.Host);
			client.AddChild(AbpIdentityServerPermissions.Client.Create, L("Permission:Create"), MultiTenancySides.Host);
			client.AddChild(AbpIdentityServerPermissions.Client.ManagePermissions, L("Permission:ManagePermissions"), MultiTenancySides.Host);
			client.AddChild(AbpIdentityServerPermissions.Client.ViewChangeHistory, L("Permission:ViewChangeHistory"), MultiTenancySides.Host);
		}

		private static LocalizableString L(string name)
		{
			LocalizableString localizableString =
				LocalizableString.Create<AbpIdentityServerResource>(name);
			return localizableString;
		}
	}
}
