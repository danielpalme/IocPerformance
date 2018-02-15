using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Conditions;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Conditional_08_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsConditional;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var importConditionObject1 = container.Resolve<ImportConditionObject1>();
            var importConditionObject2 = container.Resolve<ImportConditionObject2>();
            var importConditionObject3 = container.Resolve<ImportConditionObject3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsConditional)
            {
                return;
            }

            if (ImportConditionObject1.Instances != this.LoopCount
                || ImportConditionObject2.Instances != this.LoopCount
                || ImportConditionObject3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ImportConditionObject count must be {0}", this.LoopCount));
            }
        }
    }
}