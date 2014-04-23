using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Transient_02_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));

            if (transient1 == null || transient2 == null || transient3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ITransient1)));
            }

            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            return new BenchmarkResult(this, container)
            {
                Time = base.Measure<ITransient1, ITransient2, ITransient3>(container)
            };
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Transient1.Instances != BenchmarkBase.LoopCount
                || Transient2.Instances != BenchmarkBase.LoopCount
                || Transient3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
