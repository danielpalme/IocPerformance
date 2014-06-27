using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public class BenchmarkRunner : IBenchmarkRunner
    {
        private readonly IBenchmark _benchmark;

        private readonly IContainerAdapter _container;

        private readonly IBenchmarkMeasurer _multithreadedMeasurer;

        private readonly IBenchmarkMeasurer _singlethreadedMeasurer;

        public BenchmarkRunner(IContainerAdapter container, IBenchmark benchmark)
        {
            _container = container;
            _benchmark = benchmark;
            _singlethreadedMeasurer = new SinglethreadedBenchmarkMeasurer(container, benchmark);
            _multithreadedMeasurer = new MultithreadedBenchmarkMeasurer(container, benchmark);
        }

        public BenchmarkResult Run()
        {
            var result = new BenchmarkResult(_benchmark, _container);

            if (!_benchmark.IsSupportedBy(_container))
            {
                return result;
            }

            _benchmark.Warmup(_container);

            result.SingleThreadedResult = _singlethreadedMeasurer.Measure();
            result.MultiThreadedResult = _multithreadedMeasurer.Measure();

            return result;
        }
    }
}