using System;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public class BenchmarkResult
    {
        public BenchmarkResult(IBenchmark benchmark, IContainerAdapter container)
        {
            this.BenchmarkInfo = new BenchmarkInfo(benchmark);
            this.ContainerInfo = new ContainerAdapterInfo(container);
        }

        public BenchmarkInfo BenchmarkInfo { get; private set; }

        public ContainerAdapterInfo ContainerInfo { get; private set; }

        public Measurement SingleThreadedResult { get; set; }

        public Measurement MultiThreadedResult { get; set; }
    }
}
