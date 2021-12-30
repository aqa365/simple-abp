using System;

namespace Simple.Abp.AuditLogging.Dtos
{
    public class GetErrorRateFilter
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
