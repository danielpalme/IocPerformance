using System;
using IocPerformance.Classes.Complex;

namespace IocPerformance.Benchmarks.Basic
{
    public class Complex_04_Benchmark : BenchmarkBase
    {
        public override void Warmup(Adapters.IContainerAdapter container)
        {
            var complex1 = (IComplex1)container.Resolve(typeof(IComplex1));
            var complex2 = (IComplex2)container.Resolve(typeof(IComplex2));
            var complex3 = (IComplex3)container.Resolve(typeof(IComplex3));

            if (complex1 == null || complex2 == null || complex3 == null)
            {
                throw new Exception(string.Format("Container {0} could not create type {1}", container.Name, typeof(IComplex1)));
            }

            Complex1.Instances = 0;
            Complex2.Instances = 0;
            Complex3.Instances = 0;
        }

        public override BenchmarkResult Measure(Adapters.IContainerAdapter container)
        {
            return new BenchmarkResult(this, container)
            {
                Time = base.Measure<IComplex1, IComplex2, IComplex3>(container)
            };
        }

        public override void Verify(Adapters.IContainerAdapter container)
        {
            if (Complex1.Instances != BenchmarkBase.LoopCount
                || Complex2.Instances != BenchmarkBase.LoopCount
                || Complex3.Instances != BenchmarkBase.LoopCount)
            {
                throw new Exception(string.Format("Complex count must be {0}", BenchmarkBase.LoopCount));
            }
        }
    }
}
