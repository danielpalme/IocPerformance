using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Multiple;

namespace IocPerformance.Benchmarks.Advanced
{
    public class IEnumerable_07_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportsMultiple;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var importMultiple1 = (ImportMultiple1)container.Resolve(typeof(ImportMultiple1));
            var importMultiple2 = (ImportMultiple2)container.Resolve(typeof(ImportMultiple2));
            var importMultiple3 = (ImportMultiple3)container.Resolve(typeof(ImportMultiple3));
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsMultiple)
            {
                return;
            }

            if (ImportMultiple1.Instances != LoopCount
                || ImportMultiple2.Instances != LoopCount
                || ImportMultiple3.Instances != LoopCount)
            {
                throw new Exception(string.Format("ImportMultiple count must be {0}", LoopCount));
            }
        }
    }
}