using IocPerformance.Adapters;
using IocPerformance.Classes.Generated;

namespace IocPerformance.Benchmarks.Registration
{
    // ReSharper disable once InconsistentNaming
    public class Registration_00_Benchmark : Benchmark
    {
        public override int LoopCount
        {
            get { return 1; }
        }

        public override int Order
        {
            get { return -10; }
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            container.Register(Registrations.Components);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {}

        public override void Warmup(IContainerAdapter container)
        {
            //do nothing
        }
    }
}