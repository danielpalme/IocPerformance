using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    public class ChildContainer_09_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsChildContainer;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = childContainer.Resolve<ICombined1>();
            }

            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = childContainer.Resolve<ICombined2>();
            }

            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = childContainer.Resolve<ICombined3>();
            }
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsChildContainer)
            {
                return;
            }

            if (ScopedCombined1.Instances != this.LoopCount
                || ScopedCombined2.Instances != this.LoopCount
                || ScopedCombined3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ScopedCombined count must be {0}", this.LoopCount));
            }
        }
    }
}