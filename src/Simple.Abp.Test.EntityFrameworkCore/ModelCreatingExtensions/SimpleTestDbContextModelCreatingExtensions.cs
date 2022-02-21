using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Simple.Abp.Test.EntityFrameworkCore
{
    public static class SimpleTestDbContextModelCreatingExtensions
    {
        public static void ConfigureSimpleTest(this ModelBuilder builder,
            Action<SimpleTestModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));
            if (builder.IsTenantOnlyDatabase())
                return;


        }
    }
}
