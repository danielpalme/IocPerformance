using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Complex;

namespace IocPerformance.Benchmarks.Basic
{
    public class Complex_04_Benchmark : Benchmark
    {
        public override BenchmarkCategory Category => BenchmarkCategory.Basic;

        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = container.Resolve<IComplex1>();
            var complex2 = container.Resolve<IComplex2>();
            var complex3 = container.Resolve<IComplex3>();
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Complex1.Instances != this.LoopCount
                || Complex2.Instances != this.LoopCount
                || Complex3.Instances != this.LoopCount)
            {
                throw new Exception(string.Format("Complex count must be {0}", this.LoopCount));
            }
        }
    }
}