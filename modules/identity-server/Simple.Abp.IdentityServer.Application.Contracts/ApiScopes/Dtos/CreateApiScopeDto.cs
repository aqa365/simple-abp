using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectExtending;

namespace Simple.Abp.IdentityServer.ApiScopes.Dtos
{
    public class CreateApiScopeDto: ExtensibleObject
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public bool Emphasize { get; set; }

        public bool Required { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public List<ApiScopeClaimDto> UserClaims { get; set; }
    }
}
