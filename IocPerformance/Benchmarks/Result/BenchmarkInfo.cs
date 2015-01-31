using System;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public class BenchmarkInfo
    {
        public BenchmarkInfo(IBenchmark benchmark)
        {
            this.Name = benchmark.Name;
            this.FullName = benchmark.GetType().FullName;
        }

        public string Name { get; private set; }

        public string FullName { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Name.Equals(((BenchmarkInfo)obj).Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
