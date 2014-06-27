using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Transient_02_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));
        }
    }
}