using System;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public struct HistoricMeasurement
    {
        public string Version { get; set; }

        public Measurement SingleThreadedResult { get; set; }

        public Measurement MultiThreadedResult { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1}/{2}",
                this.Version,
                this.SingleThreadedResult,
                this.MultiThreadedResult);
        }
    }
}