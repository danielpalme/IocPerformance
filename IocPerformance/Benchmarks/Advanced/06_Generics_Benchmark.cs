using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Generics;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Generics_06_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportGeneric;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var generic1 = container.Resolve<ImportGeneric<int>>();
            var generic2 = container.Resolve<ImportGeneric<float>>();
            var generic3 = container.Resolve<ImportGeneric<object>>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportGeneric)
            {
                return;
            }

            if (ImportGeneric<int>.Instances != this.LoopCount
                || ImportGeneric<float>.Instances != this.LoopCount
                || ImportGeneric<object>.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ImportGeneric count must be {0}", this.LoopCount));
            }
        }
    }
}