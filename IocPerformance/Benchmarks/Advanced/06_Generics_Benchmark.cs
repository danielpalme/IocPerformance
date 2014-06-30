using System;
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

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportGeneric)
            {
                return;
            }

            if (ImportGeneric<int>.Instances != Benchmark.LoopCount
                || ImportGeneric<float>.Instances != Benchmark.LoopCount
                || ImportGeneric<object>.Instances != Benchmark.LoopCount)
            {
                throw new Exception(string.Format("ImportGeneric count must be {0}", Benchmark.LoopCount));
            }
        }
    }
}