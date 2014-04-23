using System;
using System.Diagnostics;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Advanced
{
    public class InterceptionWithProxy_10_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsInterception)
            {
                return;
            }

            var calculator1 = (ICalculator1)container.ResolveProxy(typeof(ICalculator1));
            calculator1.Add(1, 2);
            var calculator2 = (ICalculator2)container.ResolveProxy(typeof(ICalculator2));
            calculator2.Add(1, 2);
            var calculator3 = (ICalculator3)container.ResolveProxy(typeof(ICalculator3));
            calculator3.Add(1, 2);

            Calculator1.Instances = 0;
            Calculator2.Instances = 0;
            Calculator3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            var result = new BenchmarkResult(this, container);

            if (container.SupportsInterception)
            {
                BenchmarkBase.CollectMemory();

                var watch = new Stopwatch();

                watch.Start();

                for (int i = 0; i < BenchmarkBase.LoopCount; i++)
                {
                    var result1 = (ICalculator1)container.ResolveProxy(typeof(ICalculator1));
                    var result2 = (ICalculator2)container.ResolveProxy(typeof(ICalculator2));
                    var result3 = (ICalculator3)container.ResolveProxy(typeof(ICalculator3));

                    result1.Add(5, 10);
                    result2.Add(5, 10);
                    result3.Add(5, 10);
                }

                watch.Stop();

                result.Time = watch.ElapsedMilliseconds;
            }

            return result;
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsInterception)
            {
                return;
            }

            if (Calculator1.Instances != BenchmarkBase.LoopCount
                || Calculator2.Instances != BenchmarkBase.LoopCount
                || Calculator3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("Calculator count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
