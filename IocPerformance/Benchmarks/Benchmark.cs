using System.Text.RegularExpressions;
using IocPerformance.Adapters;
using IocPerformance.Classes.AspNet;
using IocPerformance.Classes.Child;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Conditions;
using IocPerformance.Classes.Generics;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Benchmarks
{
    public abstract class Benchmark : IBenchmark
    {
        public virtual int LoopCount => 500 * 1000;

        public virtual ThreadingCases Threading => ThreadingCases.Single | ThreadingCases.Multi;

        public string Name
        {
            get
            {
                var name = this.GetType().Name.Split('_')[0];
                return Regex.Replace(name, "[A-Z]+", m => " " + m.Value).TrimStart();
            }
        }

        public abstract BenchmarkCategory Category { get; }

        public int Order => int.Parse(this.GetType().Name.Split('_')[1]);

        public virtual bool IsSupportedBy(IContainerAdapter container) => true;

        public abstract void MethodToBenchmark(IContainerAdapter container);

        public abstract void Verify(IContainerAdapter container);

        public override string ToString() => this.Name;

        public virtual void Warmup(IContainerAdapter container)
        {
            this.MethodToBenchmark(container);
            this.ZeroCounters();
        }

        protected void ZeroCounters()
        {
            ScopedCombined1.Instances = 0;
            ScopedCombined2.Instances = 0;
            ScopedCombined3.Instances = 0;
            Complex1.Instances = 0;
            Complex2.Instances = 0;
            Complex3.Instances = 0;
            ImportConditionObject1.Instances = 0;
            ImportConditionObject2.Instances = 0;
            ImportConditionObject3.Instances = 0;
            ImportGeneric<int>.Instances = 0;
            ImportGeneric<float>.Instances = 0;
            ImportGeneric<object>.Instances = 0;
            ImportMultiple1.Instances = 0;
            ImportMultiple2.Instances = 0;
            ImportMultiple3.Instances = 0;
            ComplexPropertyObject1.Instances = 0;
            ComplexPropertyObject2.Instances = 0;
            ComplexPropertyObject3.Instances = 0;
            Calculator1.Instances = 0;
            Calculator2.Instances = 0;
            Calculator3.Instances = 0;
            Combined1.Instances = 0;
            Combined2.Instances = 0;
            Combined3.Instances = 0;
            Singleton1.Instances = 0;
            Singleton2.Instances = 0;
            Singleton3.Instances = 0;
            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;

            TestController1.DisposeCount = 0;
            TestController1.Instances = 0;
            TestController2.DisposeCount = 0;
            TestController2.Instances = 0;
            TestController3.DisposeCount = 0;
            TestController3.Instances = 0;
            ScopedService.Instances = 0;
            RepositoryTransient1.Instances = 0;
            RepositoryTransient2.Instances = 0;
            RepositoryTransient3.Instances = 0;
        }
    }
}