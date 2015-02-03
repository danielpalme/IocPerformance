using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public interface IBenchmark
    {
        string Name { get; }

        int Order { get; }

        int LoopCount { get; }

        bool IsSupportedBy(IContainerAdapter container);

        void MethodToBenchmark(IContainerAdapter container);

        void Warmup(IContainerAdapter container);

        void Verify(IContainerAdapter container);
    }
}