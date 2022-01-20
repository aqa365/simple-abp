using Simple.Abp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.Identity.Dtos
{
    public class GetIdentitySecurityLogListInput : SimplePagedAndSortedResultRequestDto
    {
        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string ApplicationName { get; set; }

        public string Identity { get; set; }

        public string UserName { get; set; }

        public string ActionName { get; set; }

        public string ClientId { get; set; }

        public string CorrelationId { get; set; }
    }
}
