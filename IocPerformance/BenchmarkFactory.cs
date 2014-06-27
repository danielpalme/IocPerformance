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
            return typeof(BenchmarkFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && typeof(IBenchmark).IsAssignableFrom(t))
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<IBenchmark>()
                 .OrderBy(b => b.Order);
        }
    }
}
