using System;
using System.Collections.Specialized;
using System.Configuration;
using Common.Logging;
using Puppy.Monitoring.Daemon.DSL;
using Quartz;
using Quartz.Impl;
using Rhino.DSL;

namespace Puppy.Monitoring.Daemon
{
    public class Daemon
    {
        private static readonly ILog log = LogManager.GetLogger<Daemon>();
        private StdSchedulerFactory schedulerFactory;
        private IScheduler scheduler;

        public void Start()
        {
            log.InfoFormat("Starting the agent");

            var factory = new DslFactory
            {
                BaseDirectory = AppDomain.CurrentDomain.BaseDirectory,
            };
            factory.Register<BaseDaemonConfigurationDSL>(new BaseDaemonConfigurationDSLEngine());

            var dsl = factory.Create<BaseDaemonConfigurationDSL>("configuration.boo");
            dsl.Prepare();
            dsl.Execute();


            schedulerFactory = new StdSchedulerFactory(ConfigurationManager.GetSection("quartz") as NameValueCollection);
            scheduler = schedulerFactory.GetScheduler();

            scheduler.Start();
        }

        public void Stop()
        {
            scheduler.Shutdown();

            log.InfoFormat("Shutting the agent down");
        }
    }
}
