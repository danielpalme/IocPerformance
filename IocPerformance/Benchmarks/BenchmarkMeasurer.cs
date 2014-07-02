using System;

using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public abstract class BenchmarkMeasurer : IBenchmarkMeasurer
    {
        protected const int TimeLimit = 3 * 60 * 1000;

        protected readonly IBenchmark Benchmark;

        protected readonly IContainerAdapter Container;

        protected BenchmarkMeasurer(IContainerAdapter container, IBenchmark benchmark)
        {
            this.Container = container;
            this.Benchmark = benchmark;
        }

        public abstract Measurement Measure();

        protected void CollectMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}