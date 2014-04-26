using System;
using System.Diagnostics;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    public class ChildContainer_09_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsChildContainer)
            {
                return;
            }

            using (var childContainer = container.CreateChildContainerAdapter())
            {
                childContainer.Prepare();

                ICombined1 scopedCombined1 = (ICombined1)childContainer.Resolve(typeof(ICombined1));
                ICombined2 scopedCombined2 = (ICombined2)childContainer.Resolve(typeof(ICombined2));
                ICombined3 scopedCombined3 = (ICombined3)childContainer.Resolve(typeof(ICombined3));

                if (scopedCombined1 == null || scopedCombined2 == null || scopedCombined3 == null)
                {
                    throw new Exception(string.Format("Child Container {0} could not create type {1}", container.Name, typeof(ICombined1)));
                }

                if (!(scopedCombined1 is ScopedCombined1) || !(scopedCombined2 is ScopedCombined2) ||
                    !(scopedCombined3 is ScopedCombined3))
                {
                    throw new Exception(string.Format(
                        "Child Container {0} resolved type incorrectly should have been {1} but was {2}",
                        container.Name,
                        typeof(ICombined1),
                        scopedCombined1.GetType()));
                }
            }

            ScopedCombined1.Instances = 0;
            ScopedCombined2.Instances = 0;
            ScopedCombined3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            var result = new BenchmarkResult(this, container);

            if (container.SupportsChildContainer)
            {
                BenchmarkBase.CollectMemory();

                var watch = new Stopwatch();

                watch.Start();

                for (int i = 1; i <= BenchmarkBase.LoopCount; i++)
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

                    // If measurement takes more than three minutes, stop and interpolate result
                    if (i % 500 == 0 && watch.ElapsedMilliseconds > 3 * 60 * 1000)
                    {
                        watch.Stop();

                        ScopedCombined1.Instances = BenchmarkBase.LoopCount;
                        ScopedCombined2.Instances = BenchmarkBase.LoopCount;
                        ScopedCombined3.Instances = BenchmarkBase.LoopCount;

                        long interpolatedResult = watch.ElapsedMilliseconds * BenchmarkBase.LoopCount / i;

                        Console.WriteLine(
                            " Child container benchmark for '{0}' was stopped after {1:f1} minutes. {2} of {3} instances have been resolved. Total execution would haven taken: {4:f1} minutes",
                            container.Name,
                            (double)watch.ElapsedMilliseconds / (1000 * 60),
                            i,
                            BenchmarkBase.LoopCount,
                            (double)interpolatedResult / (1000 * 60));
                        result.Time = interpolatedResult;

                        return result;
                    }
                }

                watch.Stop();

                result.Time = watch.ElapsedMilliseconds;
            }

            return result;
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsChildContainer)
            {
                return;
            }

            if (ScopedCombined1.Instances != BenchmarkBase.LoopCount
                || ScopedCombined2.Instances != BenchmarkBase.LoopCount
                || ScopedCombined3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("ScopedCombined count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
