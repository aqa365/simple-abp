using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Simple.Abp.CloudStorage
{
    [DependsOn(
        typeof(AbpCloudStorageApplicationContractsModule)
    )]
    public class AbpCloudStorageHttpApiModule:AbpModule
    {
    }
}
