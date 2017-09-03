using System.Collections.Generic;
using System.IO;
using IocPerformance.Benchmarks;
using Newtonsoft.Json;

namespace IocPerformance.Output
{
    public class JsonOutput : IOutput
    {
        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults)
        {
            this.Create(benchmarks, benchmarkResults, "output");
        }

        public void Create(IEnumerable<IBenchmark> benchmarks, IEnumerable<BenchmarkResult> benchmarkResults, string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var jsonResult = JsonConvert.SerializeObject(benchmarkResults, Formatting.Indented);

            File.WriteAllText(Path.Combine(directory, "result.json"), jsonResult);
        }
    }
}