using System.Text.RegularExpressions;

using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    public abstract class Benchmark : IBenchmark
    {
        public string Name
        {
            get
            {
                var name = this.GetType().Name.Split('_')[0];
                return Regex.Replace(name, "[A-Z]+", m => " " + m.Value).TrimStart();
            }
        }

        public int Order
        {
            get
            {
                return int.Parse(this.GetType().Name.Split('_')[1]);
            }
        }

        public virtual bool IsSupportedBy(IContainerAdapter container)
        {
            return true;
        }

        public abstract void MethodToBenchmark(IContainerAdapter container);

        public override string ToString()
        {
            return this.Name;
        }

        public virtual void Warmup(IContainerAdapter container)
        {
            this.MethodToBenchmark(container);
        }
    }
}