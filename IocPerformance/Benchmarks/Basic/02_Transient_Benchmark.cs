using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Transient_02_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsTransient;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsTransient)
                return;

            if (Transient1.Instances != this.LoopCount
                || Transient2.Instances != this.LoopCount
                || Transient3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }
        }
    }
}