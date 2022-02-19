using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Simple.Abp.Articles
{
    [DependsOn(
       typeof(AbpHttpClientModule),
       typeof(AbpArticlesApplicationContractsModule)
    )]
    public class AbpArticlesHttpApiClientModule:AbpModule
    {
        public const string RemoteServiceName = "AbpArticles";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpArticlesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
