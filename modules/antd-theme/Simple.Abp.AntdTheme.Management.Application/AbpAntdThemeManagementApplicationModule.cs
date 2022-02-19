using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Simple.Abp.AntdTheme
{
    [DependsOn(
        typeof(AbpDddApplicationModule),
        typeof(AbpAntdThemeManagementApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationModule))]
    public class AbpAntdThemeManagementApplicationModule:AbpModule
    {
    }
}
