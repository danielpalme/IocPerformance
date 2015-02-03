using System;
using IocPerformance.Adapters;
using IocPerformance.Classes.Complex;

namespace IocPerformance.Benchmarks.Basic
{
    public class Complex_04_Benchmark : Benchmark
    {
        public override void MethodToBenchmark(IContainerAdapter container)
        {
            var complex1 = (IComplex1)container.Resolve(typeof(IComplex1));
            var complex2 = (IComplex2)container.Resolve(typeof(IComplex2));
            var complex3 = (IComplex3)container.Resolve(typeof(IComplex3));
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Complex1.Instances != LoopCount
                || Complex2.Instances != LoopCount
                || Complex3.Instances != LoopCount)
            {
                throw new Exception(string.Format("Complex count must be {0}", LoopCount));
            }
        }
    }
}