using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.IdentityServer.ApiScopes.Dtos
{
    public class ApiScopeDto: CreateApiScopeDto
    {
        public Guid Id { get;set; }

        public Dictionary<string, string> Properties { get; set; }
    }
}
