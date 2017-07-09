using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Properties;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Property_05_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsPropertyInjection;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = container.Resolve<IComplexPropertyObject1>();
            var complex2 = container.Resolve<IComplexPropertyObject2>();
            var complex3 = container.Resolve<IComplexPropertyObject3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (!container.SupportsPropertyInjection)
            {
                return;
            }

            if (ComplexPropertyObject1.Instances != this.LoopCount
                || ComplexPropertyObject2.Instances != this.LoopCount
                || ComplexPropertyObject3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("ComplexPropertyObject count must be {0}", this.LoopCount));
            }
        }
    }
}