using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));

            if (combined1 == null || combined2 == null || combined3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ICombined1)));
            }

            Combined1.Instances = 0;
            Combined2.Instances = 0;
            Combined3.Instances = 0;

            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            return new BenchmarkResult(this, container)
            {
                Time = base.Measure<ICombined1, ICombined2, ICombined3>(container)
            };
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Combined1.Instances != BenchmarkBase.LoopCount
                || Combined2.Instances != BenchmarkBase.LoopCount
                || Combined3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("Combined count must be {0}", BenchmarkBase.LoopCount));
            }

            if (Transient1.Instances != BenchmarkBase.LoopCount
                || Transient2.Instances != BenchmarkBase.LoopCount
                || Transient3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", BenchmarkBase.LoopCount));
            }

            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}
