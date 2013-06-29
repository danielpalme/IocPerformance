
namespace IocPerformance.Output
{
	public class Result
	{
		public string Name { get; set; }

		public string Version { get; set; }

		public long SingletonTime { get; set; }

		public long TransientTime { get; set; }

		public long CombinedTime { get; set; }

		public long ComplexTime { get; set; }

		public long? GenericTime { get; set; }

		public long? ConditionalTime { get; set; }

		public long? MultipleImport { get; set; }
		
		public long? InterceptionTime { get; set; }

		public int SingletonInstances { get; set; }

		public int TransientInstances { get; set; }

		public int CombinedInstances { get; set; }

		public int ComplexInstances { get; set; }

		public int GenericInstances { get; set; }

		public int ConditionalInstances { get; set; }

		public int MultipleImportInstances { get; set; }

		public int InterceptionInstances { get; set; }
	}
}
