using System.Collections.Generic;
using System.Linq;
using IocPerformance.Adapters;
using Xunit;

namespace IocPerformance.Test
{
    public class SmokeTest
    {
        [Theory]
        [MemberData(nameof(Containers))]
        public void Warmup(IContainerAdapter container)
        {
            container.Prepare();

            var benchmarks = BenchmarkFactory.CreateBenchmarks().ToArray();

            // Run each benchmark before start measuring to ensure that all root services has been resolved.
            // Exclude the "Prepare" benchmarks as they dispose the container.
            foreach (var benchmark in benchmarks.Where(b => !b.Name.StartsWith("Prepare")))
            {
                if (benchmark.IsSupportedBy(container))
                {
                    benchmark.Warmup(container);
                }
            }
        }

        public static IEnumerable<object[]> Containers => ContainerAdapterFactory.CreateAdapters().Select(a => new object[] { a }).ToList();
    }
}
