import Puppy.Monitoring.Daemon.Tests

configure_publisher:
	context:
		system "Daemon"
		module "Schedule"
	adapter_is DSLTestAdapter()
	with_pipeline: 
		type DSLTestPipeline()
		pipelet:
			type DSLTestPipelet1()
		pipelet:
			type DSLTestPipelet2()
