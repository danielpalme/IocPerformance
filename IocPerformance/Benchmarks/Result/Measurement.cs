using System;
namespace IocPerformance.Benchmarks
{
    [Serializable]
    public struct Measurement
    {
        public long? Time { get; set; }

        public bool ExtraPolated { get; set; }

        public string Error { get; set; }

        public bool Successful => string.IsNullOrEmpty(this.Error) && !this.ExtraPolated && this.Time.HasValue;

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Error))
            {
                return this.Error;
            }
            else
            {
                return string.Format(
                    "{0}{1}",
                    this.Time,
                    this.ExtraPolated ? "*" : null);
            }
        }
    }
}
