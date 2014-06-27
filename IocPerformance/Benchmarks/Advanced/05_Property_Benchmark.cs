using IocPerformance.Adapters;
using IocPerformance.Classes.Properties;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Property_05_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportsPropertyInjection;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = (IComplexPropertyObject1)container.Resolve(typeof(IComplexPropertyObject1));
            var complex2 = (IComplexPropertyObject2)container.Resolve(typeof(IComplexPropertyObject2));
            var complex3 = (IComplexPropertyObject3)container.Resolve(typeof(IComplexPropertyObject3));
        }
    }
}