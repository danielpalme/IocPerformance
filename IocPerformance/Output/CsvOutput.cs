using System.Collections.Generic;
using System.IO;

namespace IocPerformance.Output
{
    public class CsvOutput : IOutput
    {
        private readonly List<Result> results = new List<Result>();

        public void Start()
        {
        }

        public void Result(Result result)
        {
            this.results.Add(result);
        }

        public void Finish()
        {
            if (!Directory.Exists("output"))
            {
                Directory.CreateDirectory("output");
            }

            using (var fileStream = new FileStream("output\\csv_output.csv", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("Container,Singleton,Transient,Combined,Complex,Generics,IEnumerable,Conditional,Interception");

                    foreach (Result result in this.results)
                    {
                        // write container name and resolve times
                        writer.WriteLine(
                            "{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                            result.Name,
                            result.SingletonTime,
                            result.TransientTime,
                            result.CombinedTime,
                            result.ComplexTime,
                            result.GenericTime.GetValueOrDefault(0),
                            result.MultipleImport.GetValueOrDefault(0),
                            result.ConditionalTime.GetValueOrDefault(0),
                            result.InterceptionTime.GetValueOrDefault(0));
                    }
                }
            }
        }
    }
}
