using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Auditing;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Simple.Abp.IdentityServer
{
	public class IdentityServerPermissionDefinitionProviderEntityHistoryTuner : PermissionDefinitionProvider
	{
		public override void Define(IPermissionDefinitionContext context)
		{
			var requiredService = context.ServiceProvider.GetRequiredService<IAuditingHelper>();
			if (!requiredService.IsEntityHistoryEnabled(typeof(Client)))
			{
				context.TryDisablePermission("AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.Clients.Client");
			}
			if (!requiredService.IsEntityHistoryEnabled(typeof(IdentityResource)))
			{
				context.TryDisablePermission("AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.IdentityResources.IdentityResource");
			}
			if (!requiredService.IsEntityHistoryEnabled(typeof(ApiResource)))
			{
				context.TryDisablePermission("AuditLogging.ViewChangeHistory:Volo.Abp.IdentityServer.ApiResources.ApiResource");
			}
		}
	}
}
