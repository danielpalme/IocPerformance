using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    public class ChildContainer_09_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportsChildContainer;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = (ICombined1)childContainer.Resolve(typeof(ICombined1));
            }

            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = (ICombined2)childContainer.Resolve(typeof(ICombined2));
            }

            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                var scopedCombined = (ICombined3)childContainer.Resolve(typeof(ICombined3));
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