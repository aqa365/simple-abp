using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Articles.EntityFrameworkCore
{
    public class ArticlesModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ArticlesModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
