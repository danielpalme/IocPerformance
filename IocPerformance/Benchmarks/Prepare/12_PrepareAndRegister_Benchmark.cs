using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks.Prepare
{
    /// <summary>
    /// Tests time needed to prepare container to allow resolve methods to be called.
    /// Important for elasic services, mobile/embeeded apps and office desktop add-ins start up times.
    /// Does not tests first resolution time, so lazy containers will win here.
    /// Some containers are not thread safe or do not allow several instances of same type for registration and throw error in multi threaded case, some just silent about this.
    /// </summary>
    public class PrepareAndRegister_12_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Prepare;

        // not supports multithreaded scenario
        // 1 - first container created
        // 2 - second created
        // 1 - resolving out of not ready second container, error
        // or
        // when conainer errors if no support for multi registrations of same type 
        public override ThreadingCases Threading => base.Threading & (~ThreadingCases.Multi);

        public override int LoopCount => 3 * 1000;

        public override void Warmup(IContainerAdapter container)
        {
            container.PrepareBasic();
            this.ZeroCounters();
            container.Dispose();
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            container.PrepareBasic();
            container.Dispose();
        }

        public override void Verify(IContainerAdapter container)
        {
            container.Dispose();
        }
    }
}
