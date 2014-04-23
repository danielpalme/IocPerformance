using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public abstract class BenchmarkBase
    {
        protected const int LoopCount = 1000 * 500;

        public string Name
        {
            get
            {
                string name = this.GetType().Name.ToString().Split('_')[0];
                return Regex.Replace(name, "[A-Z]", m => " " + m.Value).TrimStart();
            }
        }

        public int Order
        {
            get
            {
                return int.Parse(this.GetType().Name.ToString().Split('_')[1]);
            }
        }

        public abstract void Warmup(IContainerAdapter container);

        public abstract BenchmarkResult Measure(IContainerAdapter container);

        public abstract void Verify(IContainerAdapter container);

        public override string ToString()
        {
            return this.Name;
        }

        protected static void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Do this a second time to ensure finalizable objects that survived the previous collect are now
            // collected.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        protected long Measure<T1, T2, T3>(IContainerAdapter container)
        {
            CollectMemory();

            var watch = new Stopwatch();

            watch.Start();

            for (int i = 0; i < LoopCount; i++)
            {
                T1 result1 = (T1)container.Resolve(typeof(T1));
                T2 result2 = (T2)container.Resolve(typeof(T2));
                T3 result3 = (T3)container.Resolve(typeof(T3));
            }

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}
