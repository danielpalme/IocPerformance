using System;
using System.Collections.Generic;
using IocPerformance.Adapters;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public class BenchmarkResult
    {
        public BenchmarkResult(IBenchmark benchmark, IContainerAdapter container)
        {
            this.BenchmarkInfo = new BenchmarkInfo(benchmark);
            this.ContainerInfo = new ContainerAdapterInfo(container);
        }

        public BenchmarkInfo BenchmarkInfo { get; private set; }

        public ContainerAdapterInfo ContainerInfo { get; private set; }

        public Measurement SingleThreadedResult { get; set; }

        public Measurement MultiThreadedResult { get; set; }

        public List<HistoricMeasurement> History { get; set; } = new List<HistoricMeasurement>();

        public override string ToString()
        {
            return $"{this.ContainerInfo.Name} - {this.ContainerInfo.Version} (#History: {this.History.Count})";
        }
    }
}
