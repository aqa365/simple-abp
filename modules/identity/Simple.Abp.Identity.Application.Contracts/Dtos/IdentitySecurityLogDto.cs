using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Simple.Abp.Identity.Dtos
{
    public class IdentitySecurityLogDto :ExtensibleEntityDto<Guid>
    {
        public string ApplicationName { get; protected set; }

        public string Identity { get; protected set; }

        public string Action { get; protected set; }

        public Guid? UserId { get; protected set; }

        public string UserName { get; protected set; }

        public string TenantName { get; protected set; }

        public string ClientId { get; protected set; }

        public string CorrelationId { get; protected set; }

        public string ClientIpAddress { get; protected set; }

        public string BrowserInfo { get; protected set; }

        public DateTime CreationTime { get; protected set; }
    }
}
