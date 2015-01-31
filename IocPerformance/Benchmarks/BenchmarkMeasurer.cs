using System;

using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public abstract class BenchmarkMeasurer : IBenchmarkMeasurer
    {
        // TODO: change text for prepare/register benchmark
        protected const string TooSlowMessageFormat = " Benchmark '{0}' ({1}) was stopped after {2:f1} minutes. {3} of {4} instances have been resolved. Total execution would have taken: {5:f1} minutes.";

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