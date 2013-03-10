using Puppy.Monitoring.Adapters;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Pipeline;

namespace Puppy.Monitoring.Daemon.Tests
{
    public class DSLTestAdapter : IPipelineAdapter
    {
        public IPipeline Pipeline { get; private set; }
        public static bool WasCalled { get; private set; }

        public void Push(IEvent @event)
        {
            WasCalled = true;
        }

        public IPipelineAdapter Register(IPipeline pipeline)
        {
            Pipeline = pipeline;
            return this;
        }
    }
}