using System;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    [Flags]
    public enum ThreadingCases{
        Single = 1,
        Multi = 2
    }

    public interface IBenchmark
    {
    
        string Name { get; }

        int Order { get; }
        
        int LoopCount {get;}

        ThreadingCases Threading {get;}

        /// <summary>
        /// If false returned none methods are invoked.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        bool IsSupportedBy(IContainerAdapter container);

        /// <summary>
        /// Ensures container is prepared. Called once before looping <see cref="MethodToBenchmark/>
        /// </summary>
        /// <param name="container"></param>
        void Warmup(IContainerAdapter container);
        
        void MethodToBenchmark(IContainerAdapter container);

        /// <summary>
        /// Ensures that container behaved validly. Called once after looping <see cref="MethodToBenchmark/>.
        /// </summary>
        /// <param name="container"></param>
        /// <exception cref="Exception>Any exception indicat4es verification failure</exception>
        void Verify(IContainerAdapter container);

    }
}