@nugets = [
	{
		:package_id => 'Puppy.Monitoring.Daemon',
		:description => 'Puppy.Monitoring.Daemon',
		:authors => 'rivethead_',
		:base_folder => 'Puppy.Monitoring.Daemon/',
		:files => [
			['Puppy.Monitoring.Daemon.exe', 'lib\net45'],
			['configuration.boo', 'lib\net45'],
			['*.config', 'lib\net45'],
			['imps.xml', 'lib\net45'],
		],
		:dependencies => [
			['Common.Logging', '(2.1.1,2.12)'],
			['Puppy.Monitoring', ''],
			['Boo', '0.9.4'],
			['Boo-Compiler', '0.9.4'],
			['Quartz', '2.1.2'],
			['RhinoDSL', '1.0.0'],
			['TopShelf', '3.1.0'],
		]
	},
	{
		:package_id => 'Puppy.Monitoring.Imps',
		:description => 'Puppy.Monitoring.Imps',
		:authors => 'rivethead_',
		:base_folder => 'Puppy.Monitoring.Imps/',
		:files => [
			['Puppy.Monitoring.Imps.dll', 'lib\net45'],
			['Puppy.Monitoring.Imps.pdb', 'lib\net45']
		],
		:dependencies => [
			['Common.Logging', '(2.1.1,2.12)'],
			['Puppy.Monitoring', ''],
			['Quartz', '2.1.2'],
		]
	},
	{
		:package_id => 'Puppy.Monitoring.SqlServer.Imps',
		:description => 'Puppy.Monitoring.SqlServer.Imps',
		:authors => 'rivethead_',
		:base_folder => 'Puppy.Monitoring.SqlServer.Imps/',
		:files => [
			['Puppy.Monitoring.SqlServer.Imps.dll', 'lib\net45'],
			['Puppy.Monitoring.SqlServer.Imps.pdb', 'lib\net45']
		],
		:dependencies => [
			['Common.Logging', '(2.1.1,2.12)'],
			['Puppy.Monitoring', ''],
			['Quartz', '2.1.2'],
		]
	}
]