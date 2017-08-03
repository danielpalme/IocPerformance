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
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            var jsonResult = JsonConvert.SerializeObject(benchmarkResults, Formatting.Indented);

            File.WriteAllText("output\\result.json", jsonResult);
        }
    }
}