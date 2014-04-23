using System;
using IocPerformance.Classes.Generics;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Generics_06_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportGeneric)
            {
                return;
            }

            var generic1 = (ImportGeneric<int>)container.Resolve(typeof(ImportGeneric<int>));
            var generic2 = (ImportGeneric<float>)container.Resolve(typeof(ImportGeneric<float>));
            var generic3 = (ImportGeneric<object>)container.Resolve(typeof(ImportGeneric<object>));

            if (generic1 == null || generic2 == null || generic3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ImportGeneric<>)));
            }

            ImportGeneric<int>.Instances = 0;
            ImportGeneric<float>.Instances = 0;
            ImportGeneric<object>.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            var result = new BenchmarkResult(this, container);

            if (container.SupportGeneric)
            {
                result.Time = base.Measure<ImportGeneric<int>, ImportGeneric<float>, ImportGeneric<object>>(container);
            }

            return result;
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportGeneric)
            {
                return;
            }

            if (ImportGeneric<int>.Instances != BenchmarkBase.LoopCount
                || ImportGeneric<float>.Instances != BenchmarkBase.LoopCount
                || ImportGeneric<object>.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("ImportGeneric count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
