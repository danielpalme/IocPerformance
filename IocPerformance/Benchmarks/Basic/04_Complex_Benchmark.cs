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
    }
}