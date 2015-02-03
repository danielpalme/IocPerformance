using IocPerformance.Adapters;
using IocPerformance.Classes.Generated;

namespace IocPerformance.Benchmarks.Registration
{
    // ReSharper disable once InconsistentNaming
    public class RegistrationMultiTenant_00_Benchmark : Benchmark
    {
        public const int NumberOfTenants = 10;

        public override int LoopCount
        {
            get { return 1; }
        }

        public override int Order
        {
            get { return -9; }
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            container.RegisterMultiTenant(Registrations.Components, NumberOfTenants);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {}

        public override void Warmup(IContainerAdapter container)
        {
            //do nothing
        }
    }
}