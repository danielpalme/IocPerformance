using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public interface IBenchmark
    {
        string Name { get; }

        int Order { get; }

        bool IsSupportedBy(IContainerAdapter container);

        void MethodToBenchmark(IContainerAdapter container);

        void Warmup(IContainerAdapter container);
    }
}