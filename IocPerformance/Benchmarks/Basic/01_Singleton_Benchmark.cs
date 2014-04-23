using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks.Basic
{
    public class Singleton_01_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            Singleton1.Instances = 0;
            Singleton2.Instances = 0;
            Singleton3.Instances = 0;

            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));

            if (singleton1 == null || singleton2 == null || singleton3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(ISingleton1)));
            }
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            return new BenchmarkResult(this, container)
            {
                Time = base.Measure<ISingleton1, ISingleton2, ISingleton3>(container)
            };
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
