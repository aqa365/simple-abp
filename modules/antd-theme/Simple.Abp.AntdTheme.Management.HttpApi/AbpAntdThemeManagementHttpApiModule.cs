﻿using Volo.Abp.Modularity;

namespace Simple.Abp.AntdTheme
{
    [DependsOn(typeof(AbpAntdThemeManagementApplicationContractsModule))]
    public class AbpAntdThemeManagementHttpApiModule:AbpModule
    {
    }
}
