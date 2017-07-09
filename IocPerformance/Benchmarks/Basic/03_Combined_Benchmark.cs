using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var combined1 = container.Resolve<ICombined1>();
            var combined2 = container.Resolve<ICombined2>();
            var combined3 = container.Resolve<ICombined3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Combined1.Instances != this.LoopCount
                || Combined2.Instances != this.LoopCount
                || Combined3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Combined count must be {0}", this.LoopCount));
            }

            if (Transient1.Instances != this.LoopCount
                || Transient2.Instances != this.LoopCount
                || Transient3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
            }

            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}