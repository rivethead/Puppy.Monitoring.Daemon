using System.Collections.Generic;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Pipeline.Pipelets;

namespace Puppy.Monitoring.Daemon.Tests
{
    public class DSLTestPipelet2 : IPipelet
    {
        public IEnumerable<IEvent> Flow(IEvent @event)
        {
            return ListOfEvents.EmptyList();
        }

        public bool WantsEvent(IEvent @event)
        {
            return true;
        }
    }
}