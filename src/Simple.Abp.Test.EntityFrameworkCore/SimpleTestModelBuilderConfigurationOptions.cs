using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Simple.Abp.Test.EntityFrameworkCore
{
    public class SimpleTestModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SimpleTestModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
