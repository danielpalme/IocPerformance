using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;
using IocPerformance.Output;

namespace IocPerformance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var containers = ContainerAdapterFactory.CreateAdapters().ToArray();
            var benchmarks = BenchmarkFactory.CreateBenchmarks().ToArray();

            var benchmarkResults = new List<BenchmarkResult>();
            var existingBenchmarkResults = new List<BenchmarkResult>();

            if (args != null && args.Any(a => a.Equals("-update", StringComparison.OrdinalIgnoreCase)))
            {
                existingBenchmarkResults.AddRange(XmlOutputReader.GetExistingBenchmarkResults(benchmarks, containers));
            }

            foreach (var container in containers)
            {
                var containerBenchmarkResults = new List<BenchmarkResult>();

                Console.WriteLine("{0} {1}", container.Name, container.Version);

                try
                {
                    container.Prepare();

                    foreach (var benchmark in benchmarks)
                    {
                        var benchmarkResult = existingBenchmarkResults.SingleOrDefault(b => b.Container == container && b.Benchmark == benchmark);

                        if (benchmarkResult == null)
                        {
                            benchmark.Warmup(container);
                            benchmarkResult = benchmark.Measure(container);
                            benchmark.Verify(container);
                        }

                        containerBenchmarkResults.Add(benchmarkResult);

                        Console.WriteLine(
                            " {0}{1} {2,10}",
                            benchmarkResult.Benchmark.Name,
                            new string(' ', benchmarks.Select(b => b.Name.Length).OrderByDescending(n => n).First() - benchmarkResult.Benchmark.Name.Length),
                            benchmarkResult.Time);
                    }

                    container.Dispose();

                    // All benchmarks of container have completed, now 'commit' results
                    benchmarkResults.AddRange(containerBenchmarkResults);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" " + container.Name + " failed: " + ex.Message);
                }

                Console.WriteLine();
            }

            IOutput output = new MultiOutput(
                new HtmlOutput(),
                new MarkdownOutput(),
                new XmlOutput(),
                new CsvOutput(),
                new CsvRateOutput(),
                new ChartOutput());

            output.Create(benchmarks, benchmarkResults);

            Console.WriteLine("Done");
        }
    }
}