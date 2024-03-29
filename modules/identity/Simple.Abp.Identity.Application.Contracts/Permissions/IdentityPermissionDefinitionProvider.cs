﻿using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Identity.Localization;

namespace Simple.Abp.Identity
{
	public class IdentityPermissionDefinitionProvider : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var abpIdentity = context.AddGroup(IdentityPermissions.GroupName, L("Permission:IdentityManagement"));

			var roles = abpIdentity.AddPermission(IdentityPermissions.Roles.Default, L("Permission:RoleManagement"));
			roles.AddChild(IdentityPermissions.Roles.Create, L("Permission:Create"));
			roles.AddChild(IdentityPermissions.Roles.Update, L("Permission:Edit"));
			roles.AddChild(IdentityPermissions.Roles.Delete, L("Permission:Delete"));
			roles.AddChild(IdentityPermissions.Roles.ManagePermissions, L("Permission:ChangePermissions"));
			roles.AddChild(IdentityPermissions.Roles.ViewChangeHistory, L("Permission:ViewChangeHistory"));

			var users = abpIdentity.AddPermission(IdentityPermissions.Users.Default, L("Permission:UserManagement"));
			users.AddChild(IdentityPermissions.Users.Create, L("Permission:Create"));
			users.AddChild(IdentityPermissions.Users.Update, L("Permission:Edit"));
			users.AddChild(IdentityPermissions.Users.Delete, L("Permission:Delete"));
			users.AddChild(IdentityPermissions.Users.ManagePermissions, L("Permission:ChangePermissions"));
			users.AddChild(IdentityPermissions.Users.ViewChangeHistory, L("Permission:ViewChangeHistory"));

			var organizationUnits = abpIdentity.AddPermission(IdentityPermissions.OrganizationUnits.Default, L("Permission:OrganizationUnitManagement"));
			organizationUnits.AddChild(IdentityPermissions.OrganizationUnits.ManageOU, L("Permission:ManageOU"));
			organizationUnits.AddChild(IdentityPermissions.OrganizationUnits.ManageRoles, L("Permission:ManageRoles"));
			organizationUnits.AddChild(IdentityPermissions.OrganizationUnits.ManageUsers, L("Permission:ManageUsers"));

			var claimTypes = abpIdentity.AddPermission(IdentityPermissions.ClaimTypes.Default, L("Permission:ClaimManagement"));
			claimTypes.AddChild(IdentityPermissions.ClaimTypes.Create, L("Permission:Create"));
			claimTypes.AddChild(IdentityPermissions.ClaimTypes.Update, L("Permission:Edit"));
			claimTypes.AddChild(IdentityPermissions.ClaimTypes.Delete, L("Permission:Delete"));

			var securityLogs = abpIdentity.AddPermission(IdentityPermissions.SecurityLogs.Default, L("Permission:SecurityLogManagement"));

			abpIdentity.AddPermission(IdentityPermissions.SettingManagement, L("Permission:SettingManagement"));
			abpIdentity.AddPermission(IdentityPermissions.UserLookup.Default, L("Permission:UserLookup")).WithProviders("C");
		}

		private static LocalizableString L(string name)
		{
			return LocalizableString.Create<IdentityResource>(name);
		}
	}
}
