using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public class BenchmarkRunner : IBenchmarkRunner
    {
        private readonly IBenchmark benchmark;

        private readonly IContainerAdapter container;

        private readonly IBenchmarkMeasurer multithreadedMeasurer;

        private readonly IBenchmarkMeasurer singlethreadedMeasurer;

        public BenchmarkRunner(IContainerAdapter container, IBenchmark benchmark)
        {
            this.container = container;
            this.benchmark = benchmark;
            this.singlethreadedMeasurer = new SinglethreadedBenchmarkMeasurer(container, benchmark);
            this.multithreadedMeasurer = new MultithreadedBenchmarkMeasurer(container, benchmark);
        }

        public BenchmarkResult Run()
        {
            var result = new BenchmarkResult(this.benchmark, this.container);

            if (!this.benchmark.IsSupportedBy(this.container))
            {
                return result;
            }

            this.benchmark.Warmup(this.container);

            result.SingleThreadedResult = this.singlethreadedMeasurer.Measure();

            if (result.SingleThreadedResult.Successful)
            {
                this.benchmark.Verify(this.container);
            }

            if ((this.benchmark.Threading | ThreadingCases.Multi) == this.benchmark.Threading)
            {
                this.benchmark.Warmup(this.container);
                
                result.MultiThreadedResult = this.multithreadedMeasurer.Measure();

                if (result.MultiThreadedResult.Successful)
                {
                    this.benchmark.Verify(this.container);
                }
            }

            return result;
        }
    }
}