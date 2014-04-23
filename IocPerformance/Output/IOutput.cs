using System.Collections.Generic;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public interface IOutput
    {
        void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults);
    }
}
