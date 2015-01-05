
using System;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks.Advanced
{
	/// <summary>
	/// Tests time needed to prepare container to allow resolve methods to be called.
	/// Important for elasic services, mobile/embeeded apps and office desktop add-ins start up times.
	/// Some containers are not thread safe for registration and throw error in this case, some just silent about this.
	/// Does not tests first resolution time, so lazy containers will win here.
	/// </summary>
	public class PrepareAndRegisterTime_11_Benchmark : Benchmark
    {
		public override bool IsSupportedBy(IContainerAdapter container)
		{
			return container.SupportsBasic;
		}
		
		public override void Warmup(IContainerAdapter container)
		{
			base.Warmup(container);
			container.Dispose();
		}
		
        public override void MethodToBenchmark(IContainerAdapter container)
        {
        	container.PrepareBasic();
        }
        
		public override void Verify(IContainerAdapter container)
		{
			container.Dispose();
		}
  
    }
}
