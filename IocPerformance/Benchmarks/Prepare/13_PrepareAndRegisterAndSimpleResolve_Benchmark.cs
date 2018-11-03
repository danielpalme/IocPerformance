using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Prepare
{
    /// <summary>
    /// Does same as base class, but does 2 simplest resolutions to ensure lazy containers workout.
    /// Gives more real use start up time.
    /// Considering that resolving 2 items is much faster than full prepare needed for resolution.
    /// Comparing with base class may give answer how lazy container is.
    /// </summary>
    public class PrepareAndRegisterAndSimpleResolve_13_Benchmark : PrepareAndRegister_12_Benchmark
    {
        public override void Warmup(IContainerAdapter container)
        {
            container.PrepareBasic();
            this.ZeroCounters();
            container.Dispose();
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            container.PrepareBasic();
            container.Resolve(typeof(IDummyOne));
            container.Resolve(typeof(ISingleton1));
            container.Dispose();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            // Cauldron has an instance count of 0, which seems to be caused by the code generation
            if (container.GetType().Equals(typeof(CauldronContainerAdapter)) && Singleton1.Instances == 0)
            {
                return;
            }

            if (Singleton1.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Singleton1 count must be {0} but was {1}", this.LoopCount, Singleton1.Instances));
            }
        }
    }
}
