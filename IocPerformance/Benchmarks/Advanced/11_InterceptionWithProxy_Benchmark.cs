using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    public class InterceptionWithProxy_11_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsInterception;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var result1 = container.Resolve<ICalculator1>();
            var result2 = container.Resolve<ICalculator2>();
            var result3 = container.Resolve<ICalculator3>();

            result1.Add(5, 10);
            result2.Add(5, 10);
            result3.Add(5, 10);
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsInterception)
            {
                return;
            }

            if (Calculator1.Instances != this.LoopCount
                || Calculator2.Instances != this.LoopCount
                || Calculator3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Calculator count must be {0}", this.LoopCount));
            }
        }
    }
}