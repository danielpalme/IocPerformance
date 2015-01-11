using System;
using System.Diagnostics;

using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public class SinglethreadedBenchmarkMeasurer : BenchmarkMeasurer
    {
        public SinglethreadedBenchmarkMeasurer(IContainerAdapter container, IBenchmark benchmark)
            : base(container, benchmark)
        {
        }

        public override Measurement Measure()
        {
            this.CollectMemory();

            var watch = new Stopwatch();
            var result = new Measurement();

            watch.Start();
            try
            {
                for (var i = 0; i < this.Benchmark.LoopCount; i++)
                {
                    Benchmark.MethodToBenchmark(this.Container);

                    // If measurement takes more than three minutes, stop and interpolate result
                    if (i % 500 == 0 && watch.ElapsedMilliseconds > BenchmarkMeasurer.TimeLimit)
                    {
                        watch.Stop();

                        result.Time = watch.ElapsedMilliseconds * this.Benchmark.LoopCount / i;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(
                            BenchmarkMeasurer.TOO_SLOW_MESSAGE_FORMAT, 
                            Benchmark.Name, 
                            "single thread",
                            (double)watch.ElapsedMilliseconds / (1000 * 60), 
                            i,
                            this.Benchmark.LoopCount, 
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
                    Benchmark.Name, 
                    ex.Message);
                Console.ResetColor();

                result.Error = ex is OutOfMemoryException ? "OoM" : "Error";
            }

            watch.Stop();

            if (result.Error == null)
            {
                result.Time = watch.ElapsedMilliseconds;
            }

            return result;
        }
    }
}