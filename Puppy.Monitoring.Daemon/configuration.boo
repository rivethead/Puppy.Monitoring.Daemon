import System.Collections.Generic
import Puppy.Monitoring.Adapters.Default
import Puppy.Monitoring.Pipeline
import Puppy.Monitoring.Pipeline.Pipelets
import Puppy.Monitoring.Pipeline.Pipelets.Counting
import Puppy.Monitoring.Pipeline
import Puppy.Monitoring.Pipeline.Pipelets.Publishing
import Puppy.Monitoring.Pipeline.Pipelets.Filters
import Puppy.Monitoring.DucksboardPublisher

configure_publisher:
	context:
		system "Daemon"
		module "Schedule"
	adapter_is ManualPipelineAdapter()
	with_pipeline: 
		type QueuedEventsPipeline()
		pipelet:
			type PublishingPipelet(DucksboardPublisher(), AlwaysSatisfiedEventSpecification())
