using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IocPerformance.Output
{
    public class CsvOutputReader
    {
        private IEnumerable<Result> results;

        public Result GetExistingResult(string container)
        {
            if (this.results == null)
            {
                this.Initialize();
            }

            return results.SingleOrDefault(r => r.Name == container);
        }

        private void Initialize()
        {
            if (!File.Exists("output\\csv_output.csv"))
            {
                this.results = Enumerable.Empty<Result>();
            }
            else
            {
                this.results = File.ReadAllLines("output\\csv_output.csv")
                    .Skip(1)
                    .Select(l => this.ParseResult(l))
                    .ToArray();
            }
        }

        private Result ParseResult(string line)
        {
            string[] parts = line.Split(new[] { ',' }, StringSplitOptions.None);

            if (parts.Length != 10)
            {
                throw new InvalidOperationException("CSV file has invalid format. Please delete CSV first.");
            }

            var result = new Result();

            result.Name = parts[0];
            result.Version = parts[1];

            result.SingletonTime = long.Parse(parts[2]);
            result.TransientTime = long.Parse(parts[3]);
            result.CombinedTime = long.Parse(parts[4]);
            result.ComplexTime = long.Parse(parts[5]);

            result.GenericTime = parts[6] == "0" ? (long?)null : long.Parse(parts[6]);
            result.MultipleImport = parts[7] == "0" ? (long?)null : long.Parse(parts[7]);
            result.ConditionalTime = parts[8] == "0" ? (long?)null : long.Parse(parts[8]);
            result.InterceptionTime = parts[9] == "0" ? (long?)null : long.Parse(parts[9]);

            return result;
        }
    }
}
