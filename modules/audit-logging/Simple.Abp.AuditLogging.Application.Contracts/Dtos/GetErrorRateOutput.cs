using System.Collections.Generic;

namespace Simple.Abp.AuditLogging.Dtos
{
    public class GetErrorRateOutput
    {
        public Dictionary<string, long> Data { get; set; }
    }
}
