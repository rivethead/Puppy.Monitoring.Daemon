using System.Diagnostics;
using Common.Logging;

namespace Puppy.Monitoring.Imps.PerformanceCounterJobs
{
    public class CPUPerformanceMonitoringJob : PerformanceCountersMonitoringJob
    {
        private static readonly ILog log = LogManager.GetLogger<CPUPerformanceMonitoringJob>();

        protected override PerformanceCounter CreatePerformanceCounter()
        {
            return new PerformanceCounter("Processor", "% Processor Time", "_Total");
        }
    }
}