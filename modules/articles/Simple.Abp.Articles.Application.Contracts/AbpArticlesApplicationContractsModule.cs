using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpArticlesDomainSharedModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class AbpArticlesApplicationContractsModule:AbpModule
    {
    }
}
