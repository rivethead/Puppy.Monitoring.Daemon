using Boo.Lang.Compiler;
using Boo.Lang.Compiler.Steps;
using Rhino.DSL;

namespace Puppy.Monitoring.Daemon.DSL
{
    public class BaseDaemonConfigurationDSLEngine : DslEngine
    {
        protected override void CustomizeCompiler(BooCompiler compiler, CompilerPipeline pipeline, string[] urls)
        {
            pipeline.Insert(1,
                            new ImplicitBaseClassCompilerStep(typeof (BaseDaemonConfigurationDSL), "Prepare",
                                                              "Puppy.Monitoring.Daemon.DSL"));
            pipeline.InsertBefore(typeof (ProcessMethodBodiesWithDuckTyping),
                                  new UnderscoreNamingConventionsToPascalCaseCompilerStep());
        }
    }
}