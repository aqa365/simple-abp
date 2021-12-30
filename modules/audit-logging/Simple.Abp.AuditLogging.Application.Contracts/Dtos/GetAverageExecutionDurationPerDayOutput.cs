using System.Collections.Generic;

namespace Simple.Abp.AuditLogging.Dtos
{
    public class GetAverageExecutionDurationPerDayOutput
    {
        public Dictionary<string, double> Data { get; set; }
    }
}
