using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Combined_03_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Combined1.Instances != LoopCount
                || Combined2.Instances != LoopCount
                || Combined3.Instances != LoopCount)
            {
                throw new Exception(string.Format("Combined count must be {0}", LoopCount));
            }

            if (Transient1.Instances != LoopCount
                || Transient2.Instances != LoopCount
                || Transient3.Instances != LoopCount)
            {
                throw new Exception(string.Format("Transient count must be {0}", LoopCount));
            }

            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}