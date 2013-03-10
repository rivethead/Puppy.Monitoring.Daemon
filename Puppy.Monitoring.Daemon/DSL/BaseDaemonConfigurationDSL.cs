using Boo.Lang;
using Boo.Lang.Compiler.Ast;
using Common.Logging;
using Puppy.Monitoring.Adapters;
using Puppy.Monitoring.Adapters.Default;
using Puppy.Monitoring.Pipeline;
using Puppy.Monitoring.Pipeline.Pipelets;
using Puppy.Monitoring.Publishing;

namespace Puppy.Monitoring.Daemon.DSL
{
    public abstract class BaseDaemonConfigurationDSL
    {
        public delegate void ActionDelegate();
        private static readonly ILog log = LogManager.GetLogger<BaseDaemonConfigurationDSL>();
        private readonly List<IPipelet> pipelets = new List<IPipelet>();

        private IPipelineAdapter adapter = new NullPipelineAdapter();
        protected ActionDelegate configuration;
        private IPipeline pipeline = new NullPipeline();
        private string systemName;
        private string moduleName;

        [Meta]
        public static Expression configure_publisher(Expression expression)
        {
            return expression;
        }

        public abstract void Prepare();

        public void Execute()
        {
            configuration();

            foreach (var pipelet in pipelets)
            {
                log.InfoFormat("Adding {0} to pipeline {1}", pipelet.GetType(), pipeline.GetType());
                pipeline.Add(pipelet);
            }

            log.InfoFormat("Adding {0} pipeline to {1} adapter", pipeline.GetType(), adapter.GetType());
            adapter.Register(pipeline);

            log.InfoFormat("Registering adapter {0} with Publisher", adapter.GetType());
            Publisher.Reset();
            Publisher.Use(adapter, new PublishingContext(systemName, moduleName));
        }

        public void context(ActionDelegate contextDelegate)
        {
            contextDelegate();
        }

        public void system(string systemName)
        {
            this.systemName = systemName;
        }

        public void module(string moduleName)
        {
            this.moduleName = moduleName;
        }

        public void AdapterIs(IPipelineAdapter adapter)
        {
            this.adapter = adapter;
        }

        public void WithPipeline(ActionDelegate pipelineDelagate)
        {
            pipelineDelagate();
        }


        public void pipelet(ActionDelegate pipeletDelegate)
        {
            pipeletDelegate();
        }

        public void type(IPipelet pipelet)
        {
            this.pipelets.Add(pipelet);
        }

        public void type(IPipeline pipeline)
        {
            this.pipeline = pipeline;
        }

        public void ConfigurePublisher(ActionDelegate action)
        {
            this.configuration = action;
        }
    }
}