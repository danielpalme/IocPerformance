using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;

namespace IocPerformance
{
    internal static class BenchmarkFactory
    {
        public static IEnumerable<IBenchmark> CreateBenchmarks()
        {
            var benchmarks = typeof(BenchmarkFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && typeof(IBenchmark).IsAssignableFrom(t))
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<IBenchmark>()
                 .OrderBy(b => b.Order);

            if (benchmarks.Count() != benchmarks.Select(b => b.Name).Distinct().Count())
            {
                var duplicateNames = benchmarks
                    .GroupBy(b => b.Name)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);

                throw new InvalidOperationException(string.Format(
                    "Benchmarks must have unique names, the following names are used several times: {0}",
                    string.Join(", ", duplicateNames)));
            }

            return benchmarks;
        }
    }
}
