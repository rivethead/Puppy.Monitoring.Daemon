using System;
using Puppy.Monitoring.Daemon.DSL;
using Puppy.Monitoring.Events;
using Puppy.Monitoring.Publishing;
using Rhino.DSL;
using Xunit.Extensions;

namespace Puppy.Monitoring.Daemon.Tests
{
    public class when_configuring_daemon_using_dsl : Specification
    {
        private readonly DSLTestEvent test_event;
        private readonly Publisher publisher;

        public when_configuring_daemon_using_dsl()
        {
            test_event = new DSLTestEvent(new Categorisation("TEST"), Guid.Empty);

            publisher = new Publisher();

            var factory = new DslFactory
            {
                BaseDirectory = AppDomain.CurrentDomain.BaseDirectory,
            };
            factory.Register<BaseDaemonConfigurationDSL>(new BaseDaemonConfigurationDSLEngine());

            var dsl = factory.Create<BaseDaemonConfigurationDSL>("configuration.boo");
            dsl.Prepare();
            dsl.Execute();
        }

        public override void Observe()
        {
            publisher.Publish(test_event);
        }

        [Observation]
        public void the_context_on_the_event_is_updated()
        {
            test_event.Context.ShouldNotBeNull();
            test_event.Context.System.ShouldEqual("Daemon");
            test_event.Context.Module.ShouldEqual("Schedule");
        }

        [Observation]
        public void the_adapter_is_connected_to_the_publisher()
        {
            DSLTestAdapter.WasCalled.ShouldBeTrue();
        }

        [Observation]
        public void the_configured_pipeline_is_used_during_publishing()
        {
            DSLTestPipeline.Pipelets.Count.ShouldEqual(2);
        }



    }
}