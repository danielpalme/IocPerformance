using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Transient_02_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var transient1 = container.Resolve<ITransient1>();
            var transient2 = container.Resolve<ITransient2>();
            var transient3 = container.Resolve<ITransient3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Transient1.Instances != this.LoopCount
                || Transient2.Instances != this.LoopCount
                || Transient3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }
        }
    }
}