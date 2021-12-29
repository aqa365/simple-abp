using System;
using Volo.Abp.Reflection;

namespace Simple.Abp.IdentityServer
{
	public class AbpIdentityServerPermissions
	{
		public static string[] GetAll()
		{
			return ReflectionHelper.GetPublicConstantsRecursively(typeof(AbpIdentityServerPermissions));
		}

		public const string GroupName = "IdentityServer";

		public static class IdentityResource
		{
			public const string Default = "IdentityServer.IdentityResource";

			public const string Delete = "IdentityServer.IdentityResource.Delete";

			public const string Update = "IdentityServer.IdentityResource.Update";

			public const string Create = "IdentityServer.IdentityResource.Create";

			public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.IdentityResources.IdentityResource";
		}

		public static class ApiResource
		{
			public const string Default = "IdentityServer.ApiResource";

			public const string Delete = "IdentityServer.ApiResource.Delete";

			public const string Update = "IdentityServer.ApiResource.Update";

			public const string Create = "IdentityServer.ApiResource.Create";

			public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.ApiResources.ApiResource";
		}

		public static class Client
		{
			public const string Default = "IdentityServer.Client";

			public const string Delete = "IdentityServer.Client.Delete";

			public const string Update = "IdentityServer.Client.Update";

			public const string Create = "IdentityServer.Client.Create";

			public const string ManagePermissions = "IdentityServer.Client.ManagePermissions";

			public const string ViewChangeHistory = "AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.Clients.Client";
		}
	}
}
