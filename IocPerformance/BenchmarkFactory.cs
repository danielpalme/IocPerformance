using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;

namespace IocPerformance
{
    internal static class BenchmarkFactory
    {
        public static IEnumerable<BenchmarkBase> CreateBenchmarks()
        {
            var benchmarks = typeof(BenchmarkFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BenchmarkBase)))
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<BenchmarkBase>()
                 .OrderBy(b => b.Order);

            foreach (var benchmark in benchmarks)
            {
                yield return benchmark;
            }
        }
    }
}
