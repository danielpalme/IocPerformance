using IocPerformance.Adapters;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    /// <summary>
    /// Does same as base class, but does 2 simplest resolutions to ensure lazy containers workout.
    /// Gives more real use start up time.
    /// Considering that resolving 2 items is much faster than full prepare needed for resolution.
    /// Comparing with base class may give answer how lazy container is.
    /// </summary>
    public class PrepareAndRegisterAndSimpleResolve_12_Benchmark : PrepareAndRegister_11_Benchmark
    {
        public override void Warmup(IContainerAdapter container)
        {
            container.PrepareBasic();
            this.ZeroCounters();
            container.Dispose();
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            base.MethodToBenchmark(container);
            container.Resolve(typeof(IDummyOne));
            container.Resolve(typeof(ISingleton1));
        }
    }
}
