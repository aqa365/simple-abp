using System;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.Localization;

namespace Simple.Abp.IdentityServer
{
	public abstract class IdentityServerAppServiceBase : ApplicationService
	{
		protected IdentityServerAppServiceBase()
		{
			base.ObjectMapperContext = typeof(AbpIdentityServerApplicationModule);
			base.LocalizationResource = typeof(AbpIdentityServerResource);
		}
	}
}
