using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.IdentityServer.ApiScopes.Dtos
{
    public class ApiScopeClaimDto
    {
        public string Type { get; set; }

        public Guid? ApiScopeId { get; set; }
    }
}
