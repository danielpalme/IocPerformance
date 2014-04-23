using System;
using IocPerformance.Classes.Multiple;

namespace IocPerformance.Benchmarks.Advanced
{
    public class IEnumerable_07_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsMultiple)
            {
                return;
            }

            var importMultiple1 = (ImportMultiple1)container.Resolve(typeof(ImportMultiple1));
            var importMultiple2 = (ImportMultiple2)container.Resolve(typeof(ImportMultiple2));
            var importMultiple3 = (ImportMultiple3)container.Resolve(typeof(ImportMultiple3));

            if (importMultiple1 == null || importMultiple2 == null || importMultiple3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ImportMultiple1)));
            }

            ImportMultiple1.Instances = 0;
            ImportMultiple2.Instances = 0;
            ImportMultiple3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            var result = new BenchmarkResult(this, container);

            if (container.SupportsMultiple)
            {
                result.Time = base.Measure<ImportMultiple1, ImportMultiple2, ImportMultiple3>(container);
            }

            return result;
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsMultiple)
            {
                return;
            }

            if (ImportMultiple1.Instances != BenchmarkBase.LoopCount
                || ImportMultiple2.Instances != BenchmarkBase.LoopCount
                || ImportMultiple3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("ImportMultiple count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
