using Volo.Abp.Modularity;
namespace Simple.Abp.Articles
{
    [DependsOn(
        typeof(AbpArticlesDomainSharedModule)
    )]
    public class AbpArticlesDomainModule:AbpModule
    {

    }
}
