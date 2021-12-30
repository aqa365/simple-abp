using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Simple.Abp.Articles.EntityFrameworkCore;
using Simple.Abp.Test;
using System;
using Volo.Abp;

namespace Simple.Abp.Test.EntityFrameworkCore
{ 
    public static class SimpleTestDbContextModelBuilderExtensions
    {
        public static void ConfigureSimpleTest(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] Action<SimpleTestModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SimpleTestModelBuilderConfigurationOptions(
                SimpleTestConsts.DbTablePrefix,
                SimpleTestConsts.DbSchema
            );

            optionsAction?.Invoke(options);
        }
    }
}
