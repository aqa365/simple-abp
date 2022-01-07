using Volo.Abp.Reflection;

namespace Simple.Abp.Identity
{
	public static class IdentityPermissions
	{
		public static string[] GetAll()
		{
			return ReflectionHelper.GetPublicConstantsRecursively(typeof(IdentityPermissions));
		}

		public const string GroupName = "SimpleAbpIdentity";

		public const string SettingManagement = "SimpleAbpIdentity.SettingManagement";

		public static class Roles
		{
			public const string Default = "SimpleAbpIdentity.Roles";

			public const string Create = "SimpleAbpIdentity.Roles.Create";

			public const string Update = "SimpleAbpIdentity.Roles.Update";

			public const string Delete = "SimpleAbpIdentity.Roles.Delete";

			public const string ManagePermissions = "SimpleAbpIdentity.Roles.ManagePermissions";

			public const string ViewChangeHistory = "SimpleAbpIdentity.ViewChangeHistory:Simple.Abp.Identity.IdentityRole";
		}

		public static class Users
		{
			public const string Default = "SimpleAbpIdentity.Users";

			public const string Create = "SimpleAbpIdentity.Users.Create";

			public const string Update = "SimpleAbpIdentity.Users.Update";

			public const string Delete = "SimpleAbpIdentity.Users.Delete";

			public const string ManagePermissions = "SimpleAbpIdentity.Users.ManagePermissions";

			public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Simple.Abp.Identity.IdentityUser";
		}

		public static class ClaimTypes
		{
			public const string Default = "SimpleAbpIdentity.ClaimTypes";

			public const string Create = "SimpleAbpIdentity.ClaimTypes.Create";

			public const string Update = "SimpleAbpIdentity.ClaimTypes.Update";

			public const string Delete = "SimpleAbpIdentity.ClaimTypes.Delete";
		}

		public static class UserLookup
		{
			public const string Default = "SimpleAbpIdentity.UserLookup";
		}

		public static class OrganizationUnits
		{
			public const string Default = "SimpleAbpIdentity.OrganizationUnits";

			public const string ManageOU = "SimpleAbpIdentity.OrganizationUnits.ManageOU";

			public const string ManageRoles = "SimpleAbpIdentity.OrganizationUnits.ManageRoles";

			public const string ManageUsers = "SimpleAbpIdentity.OrganizationUnits.ManageMembers";
		}
	}
}
