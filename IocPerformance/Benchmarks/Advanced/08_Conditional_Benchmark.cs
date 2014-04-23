using System;
using IocPerformance.Classes.Conditions;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Conditional_08_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsConditional)
            {
                return;
            }

            var importConditionObject1 = (ImportConditionObject1)container.Resolve(typeof(ImportConditionObject1));
            var importConditionObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
            var importConditionObject3 = (ImportConditionObject3)container.Resolve(typeof(ImportConditionObject3));

            if (importConditionObject1 == null || importConditionObject2 == null || importConditionObject3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ImportConditionObject1)));
            }

            ImportConditionObject1.Instances = 0;
            ImportConditionObject2.Instances = 0;
            ImportConditionObject3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            var result = new BenchmarkResult(this, container);

            if (container.SupportsConditional)
            {
                result.Time = base.Measure<ImportConditionObject1, ImportConditionObject2, ImportConditionObject3>(container);
            }

            return result;
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsConditional)
            {
                return;
            }

            if (ImportConditionObject1.Instances != BenchmarkBase.LoopCount
                || ImportConditionObject2.Instances != BenchmarkBase.LoopCount
                || ImportConditionObject3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("ImportConditionObject count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
