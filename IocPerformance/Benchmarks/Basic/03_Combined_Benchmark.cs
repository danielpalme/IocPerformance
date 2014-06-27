using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));
        }
    }
}