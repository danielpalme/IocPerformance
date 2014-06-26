using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public abstract class BenchmarkBase
    {
        protected const int LoopCount = 1000 * 500;

        private const int NumberOfThreads = 2;

        public string Name
        {
            get
            {
                string name = this.GetType().Name.ToString().Split('_')[0];
                return Regex.Replace(name, "[A-Z]+", m => " " + m.Value).TrimStart();
            }
        }

        public int Order
        {
            get
            {
                return int.Parse(this.GetType().Name.ToString().Split('_')[1]);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public abstract BenchmarkResult Measure(IContainerAdapter container);

        protected abstract void Warmup(IContainerAdapter container);

        protected abstract void Verify(IContainerAdapter container);

        protected BenchmarkResult Measure<T1, T2, T3>(IContainerAdapter container)
        {
            return this.Measure(
                container,
                () =>
                {
                    T1 result1 = (T1)container.Resolve(typeof(T1));
                    T2 result2 = (T2)container.Resolve(typeof(T2));
                    T3 result3 = (T3)container.Resolve(typeof(T3));
                });
        }

        protected BenchmarkResult Measure(IContainerAdapter container, Action action)
        {
            var result = new BenchmarkResult(this, container);

            // Test with a single thread
            this.Warmup(container);
            result.SingleThreadedResult = this.Measure(action, 1);
            if (result.SingleThreadedResult.Successful)
            {
                this.Verify(container);
            }

            // Test with a multiple threads
            this.Warmup(container);
            result.MultiThreadedResult = this.Measure(action, NumberOfThreads);
            if (result.MultiThreadedResult.Successful)
            {
                this.Verify(container);
            }

            return result;
        }

        private Measurement Measure(Action action, int numberOfThreads)
        {
            this.CollectMemory();

            var watch = new Stopwatch();

            Measurement result = new Measurement();

            if (numberOfThreads == 1)
            {
                watch.Start();
                try
                {
                    for (int i = 0; i < LoopCount; i++)
                    {
                        action();

                        // If measurement takes more than three minutes, stop and interpolate result
                        if (i % 500 == 0 && watch.ElapsedMilliseconds > 3 * 60 * 1000)
                        {
                            watch.Stop();

                            result.Time = watch.ElapsedMilliseconds * BenchmarkBase.LoopCount / i;

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(
                                " Benchmark '{0}' (single thread) was stopped after {1:f1} minutes. {2} of {3} instances have been resolved. Total execution would have taken: {4:f1} minutes.",
                                this.Name,
                                (double)watch.ElapsedMilliseconds / (1000 * 60),
                                i,
                                BenchmarkBase.LoopCount,
                                (double)result.Time / (1000 * 60));
                            Console.ResetColor();

                            result.ExtraPolated = true;
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.CollectMemory();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                               " Benchmark '{0}' (single thread) failed: {1}",
                               this.Name,
                               ex.Message);
                    Console.ResetColor();

                    result.Error = ex is OutOfMemoryException ? "OoM" : "Error";
                }
            }
            else
            {
                int loopcount = LoopCount / numberOfThreads;
                int counter = 0;
                Exception exception = null;

                var threads = Enumerable.Range(0, numberOfThreads)
                    .Select(i => new Thread(() =>
                    {
                        try
                        {
                            for (int j = 0; j < loopcount; j++)
                            {
                                counter++; // Interlocked.Increment would be more exact but not required here
                                action();

                                // If measurement takes more than three minutes, stop and interpolate result
                                if (result.ExtraPolated || (i % 500 == 0 && watch.ElapsedMilliseconds > 3 * 60 * 1000))
                                {
                                    watch.Stop();
                                    result.ExtraPolated = true;
                                    break;
                                }

                                if (exception != null)
                                {
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            this.CollectMemory();

                            exception = ex;
                        }
                    }))
                    .ToList();

                watch.Start();

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }

                if (exception != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        " Benchmark '{0}' (multiple threads) failed: {1}",
                        this.Name,
                        exception.Message);
                    Console.ResetColor();

                    result.Error = exception is OutOfMemoryException ? "OoM" : "Error";
                }
                else if (result.ExtraPolated)
                {
                    result.Time = watch.ElapsedMilliseconds * BenchmarkBase.LoopCount / counter;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(
                        " Benchmark '{0}' (multiple threads) was stopped after {1:f1} minutes. About {2} of {3} instances have been resolved. Total execution would have taken: {4:f1} minutes.",
                        this.Name,
                        (double)watch.ElapsedMilliseconds / (1000 * 60),
                        counter,
                        BenchmarkBase.LoopCount,
                        (double)result.Time / (1000 * 60));
                    Console.ResetColor();

                    return result;
                }
            }

            watch.Stop();

            if (result.Error == null)
            {
                result.Time = watch.ElapsedMilliseconds;
            }

            return result;
        }

        private void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

            // Ensure finalizable objects that survived the previous collect are now collected.
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
