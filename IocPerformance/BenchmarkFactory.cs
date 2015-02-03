using System;
using System.Collections.Generic;
using System.Linq;
using IocPerformance.Benchmarks;
using IocPerformance.Benchmarks.Advanced;
using IocPerformance.Benchmarks.Basic;
using IocPerformance.Benchmarks.Registration;

namespace IocPerformance
{
    internal static class BenchmarkFactory
    {
        public static IEnumerable<IBenchmark> CreateBenchmarks()
        {
            return typeof(BenchmarkFactory).Assembly.GetTypes()
                 .Where(t => t.IsClass && !t.IsAbstract && typeof(IBenchmark).IsAssignableFrom(t))
                 .Where(t => 
                     t == typeof(Registration_00_Benchmark)
                     || t == typeof(RegistrationMultiTenant_00_Benchmark)
                     || t == typeof(Singleton_01_Benchmark)
                     || t == typeof(Transient_02_Benchmark)
                     || t == typeof(Combined_03_Benchmark)
                     || t == typeof(Complex_04_Benchmark)
                     )
                 //.Where(t => t != typeof(Conditional_08_Benchmark)
                 //    && t != typeof(ChildContainer_09_Benchmark)
                 //    && t != typeof(InterceptionWithProxy_10_Benchmark)
                 //    )
                 .Select(t => Activator.CreateInstance(t))
                 .Cast<IBenchmark>()
                 .OrderBy(b => b.Order);
        }
    }
}
