using System;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public class BenchmarkInfo
    {
        public BenchmarkInfo(IBenchmark benchmark)
        {
            this.Category = benchmark.Category;
            this.Name = benchmark.Name;
            this.FullName = benchmark.GetType().FullName;
        }

        public BenchmarkCategory Category { get; private set; }

        public string Name { get; private set; }

        public string FullName { get; set; }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Name.Equals(((BenchmarkInfo)obj).Name);
        }

        public override int GetHashCode() => this.Name.GetHashCode();
    }
}
