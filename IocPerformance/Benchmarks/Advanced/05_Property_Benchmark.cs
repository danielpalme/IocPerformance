using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Properties;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Property_05_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Advanced;

        public override bool IsSupportedBy(IContainerAdapter container) => container.SupportsPropertyInjection;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = (IComplexPropertyObject1)container.Resolve(typeof(IComplexPropertyObject1));
            var complex2 = (IComplexPropertyObject2)container.Resolve(typeof(IComplexPropertyObject2));
            var complex3 = (IComplexPropertyObject3)container.Resolve(typeof(IComplexPropertyObject3));
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