using System.Collections.Generic;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public interface IOutput
    {
        void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults);
    }
}
