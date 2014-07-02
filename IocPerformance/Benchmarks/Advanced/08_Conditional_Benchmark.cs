using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Conditions;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Conditional_08_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportsConditional;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var importConditionObject1 = (ImportConditionObject1)container.Resolve(typeof(ImportConditionObject1));
            var importConditionObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
            var importConditionObject3 = (ImportConditionObject3)container.Resolve(typeof(ImportConditionObject3));
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsConditional)
            {
                return;
            }

            if (ImportConditionObject1.Instances != Benchmark.LoopCount
                || ImportConditionObject2.Instances != Benchmark.LoopCount
                || ImportConditionObject3.Instances != Benchmark.LoopCount)
            {
                throw new Exception(string.Format("ImportConditionObject count must be {0}", Benchmark.LoopCount));
            }
        }
    }
}