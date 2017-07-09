using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Singleton_01_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var singleton1 = container.Resolve<ISingleton1>();
            var singleton2 = container.Resolve<ISingleton2>();
            var singleton3 = container.Resolve<ISingleton3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                throw new Exception("Singleton instance count must be 1. Container: " + container.Name);
            }
        }
    }
}