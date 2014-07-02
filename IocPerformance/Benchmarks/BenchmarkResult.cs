using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public class BenchmarkResult
    {
        public BenchmarkResult(IBenchmark benchmark, IContainerAdapter container)
        {
            this.Benchmark = benchmark;
            this.Container = container;
        }

        public IBenchmark Benchmark { get; private set; }

        public IContainerAdapter Container { get; private set; }

        public Measurement SingleThreadedResult { get; set; }

        public Measurement MultiThreadedResult { get; set; }
    }
}
