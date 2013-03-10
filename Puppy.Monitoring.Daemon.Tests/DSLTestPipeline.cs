using System.Collections.Generic;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Pipeline;
using Puppy.Monitoring.Pipeline.Pipelets;

namespace Puppy.Monitoring.Daemon.Tests
{
    public class DSLTestPipeline : IPipeline
    {
        public static List<IPipelet> Pipelets { get; private set; }

        static DSLTestPipeline()
        {
            Pipelets = new List<IPipelet>();
        }

        public void Flow(IEvent @event)
        {
            
        }

        public IPipeline Add(IPipelet pipelet)
        {
            Pipelets.Add(pipelet);
            return this;
        }
    }
}