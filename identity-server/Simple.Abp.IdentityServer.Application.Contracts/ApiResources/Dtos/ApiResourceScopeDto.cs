using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.IdentityServer.ApiResources.Dtos
{
    public class ApiResourceScopeDto
    {
        public virtual Guid ApiResourceId { get; set; }

        public string Scope { get; set; }
    }
}
