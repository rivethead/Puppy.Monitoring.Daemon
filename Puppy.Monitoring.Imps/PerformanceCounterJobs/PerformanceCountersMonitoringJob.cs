using System.Diagnostics;
using Common.Logging;
using Quartz;

namespace Puppy.Monitoring.Imps.PerformanceCounterJobs
{
    public abstract class PerformanceCountersMonitoringJob : IJob
    {
        private static readonly ILog log = LogManager.GetLogger<PerformanceCountersMonitoringJob>();

        public void Execute(IJobExecutionContext context)
        {
            log.InfoFormat("Executing the {0} job", GetType());

            var counter = CreatePerformanceCounter();

            log.DebugFormat(counter.NextValue().ToString());
            log.DebugFormat(counter.NextValue().ToString());
            log.DebugFormat(counter.NextValue().ToString());
            
        }

        protected abstract PerformanceCounter CreatePerformanceCounter();
    }
}