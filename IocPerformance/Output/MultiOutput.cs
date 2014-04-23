using System.Collections.Generic;
using IocPerformance.Benchmarks;

namespace IocPerformance.Output
{
    public class MultiOutput : IOutput
    {
        private readonly IEnumerable<IOutput> outputs;

        public MultiOutput(params IOutput[] outputs)
        {
            this.outputs = outputs;
        }

        public void Create(IEnumerable<BenchmarkBase> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            foreach (var output in this.outputs)
            {
                output.Create(benchmarks, benchmarkResults);
            }
        }
    }
}
