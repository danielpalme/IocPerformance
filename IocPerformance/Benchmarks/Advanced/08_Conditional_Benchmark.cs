using IocPerformance.Adapters;
using IocPerformance.Classes.Conditions;

namespace IocPerformance.Benchmarks.Advanced
{
    public class Conditional_08_Benchmark : Benchmark
    {
        public override bool IsSupportedBy(IContainerAdapter container)
        {
            return container.SupportsConditional;
        }

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var importConditionObject1 = (ImportConditionObject1)container.Resolve(typeof(ImportConditionObject1));
            var importConditionObject2 = (ImportConditionObject2)container.Resolve(typeof(ImportConditionObject2));
            var importConditionObject3 = (ImportConditionObject3)container.Resolve(typeof(ImportConditionObject3));
        }
    }
}