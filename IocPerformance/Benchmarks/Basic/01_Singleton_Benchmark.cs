using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Singleton_01_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            //TODO: check not null cause some frameworks return null when type not found, so verified that there are not badly written adapters
            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));
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