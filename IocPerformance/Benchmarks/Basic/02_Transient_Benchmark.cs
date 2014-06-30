using System;
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

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Transient1.Instances != Benchmark.LoopCount
                || Transient2.Instances != Benchmark.LoopCount
                || Transient3.Instances != Benchmark.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", Benchmark.LoopCount));
            }
        }
    }
}