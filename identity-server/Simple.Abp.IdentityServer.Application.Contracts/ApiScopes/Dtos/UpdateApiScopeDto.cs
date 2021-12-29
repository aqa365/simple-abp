using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.IdentityServer.ApiScopes.Dtos
{
    public class UpdateApiScopeDto: CreateApiScopeDto
    {
        public Dictionary<string, string> Properties { get; set; }
    }
}
