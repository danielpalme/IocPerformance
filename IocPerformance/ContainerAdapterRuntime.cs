using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Adapters;
using IocPerformance.Benchmarks;

namespace IocPerformance
{
    /// <summary>
    /// Executes the benchmarks for the given container.
    /// Implements <see cref="MarshalByRefObject"/> to allow execution in separate AppDomain.
    /// </summary>
    public class ContainerAdapterRuntime : MarshalByRefObject
    {
        public List<BenchmarkResult> Run(Type containerType, List<BenchmarkResult> existingBenchmarkResults)
        {
            var container = (IContainerAdapter)Activator.CreateInstance(containerType);
            var benchmarks = BenchmarkFactory.CreateBenchmarks().ToArray();

            var containerBenchmarkResults = new List<BenchmarkResult>();

            Console.WriteLine(
                "{0} {1}{2} {3,10} {4,10}",
                container.Name,
                container.Version,
                new string(' ', benchmarks.Select(b => b.Name.Length).OrderByDescending(n => n).First() - container.Name.Length - container.Version.Length),
                "Single",
                "Multi");

            try
            {
                container.Prepare();

                foreach (var benchmark in benchmarks)
                {
                    var benchmarkResult = existingBenchmarkResults.SingleOrDefault(b => b.ContainerInfo.Name == container.Name && b.BenchmarkInfo.Name == benchmark.Name);

                    if (benchmarkResult == null)
                    {
                        benchmarkResult = new BenchmarkRunner(container, benchmark).Run();
                    }

                    containerBenchmarkResults.Add(benchmarkResult);

                    Console.WriteLine(
                        " {0}{1} {2,10} {3,10}",
                        benchmarkResult.BenchmarkInfo,
                        new string(' ', benchmarks.Select(b => b.Name.Length).OrderByDescending(n => n).First() - benchmarkResult.BenchmarkInfo.Name.Length),
                        benchmarkResult.SingleThreadedResult,
                        benchmarkResult.MultiThreadedResult);
                }
            }
            finally
            {
                container.Dispose();
            }

            return containerBenchmarkResults;
        }
    }
}
