using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Singleton_01_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));
        }
    }
}