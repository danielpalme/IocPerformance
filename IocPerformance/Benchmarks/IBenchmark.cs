using System;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    [Flags]
    public enum ThreadingCases
    {
        Single = 1,
        Multi = 2
    }

    public interface IBenchmark
    {
        BenchmarkCategory Category { get; }

        string Name { get; }

        int Order { get; }

        int LoopCount { get; }

        ThreadingCases Threading { get; }

        /// <summary>
        /// If false returned no methods are invoked.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns><c>true</c> if supported otherwise <c>false</c></returns>
        bool IsSupportedBy(IContainerAdapter container);

        /// <summary>
        /// Ensures container is prepared. Called once before looping <see cref="MethodToBenchmark"/>
        /// </summary>
        /// <param name="container">The container.</param>
        void Warmup(IContainerAdapter container);

        void MethodToBenchmark(IContainerAdapter container);

        /// <summary>
        /// Ensures that container behaved validly. Called once after looping <see cref="MethodToBenchmark"/>.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="Exception">Any exception indicates verification failure</exception>
        void Verify(IContainerAdapter container);
    }
}