using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public class BenchmarkResult
    {
        public BenchmarkResult(BenchmarkBase benchmark, IContainerAdapter container)
        {
            this.Benchmark = benchmark;
            this.Container = container;
        }

        public BenchmarkBase Benchmark { get; private set; }

        public IContainerAdapter Container { get; private set; }

        public Measurement SingleThreadedResult { get; set; }

        public Measurement MultiThreadedResult { get; set; }
    }
}
