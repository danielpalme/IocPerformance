using IocPerformance.Adapters;
using IocPerformance.Classes.Generics;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Generics_06_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportGeneric;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var generic1 = (ImportGeneric<int>)container.Resolve(typeof(ImportGeneric<int>));
            var generic2 = (ImportGeneric<float>)container.Resolve(typeof(ImportGeneric<float>));
            var generic3 = (ImportGeneric<object>)container.Resolve(typeof(ImportGeneric<object>));
        }
    }
}