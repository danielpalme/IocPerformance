using System;
using System.Collections.Generic;
using System.IO;

namespace IocPerformance.Output
{
    /// <summary>
    /// Returns csv_Rate.csv, each value is a rate of comparing with the base value in NoContainerAdapter. 
    /// It makes the measurements to be independent of the hardware installed.
    /// </summary>
    public class CsvRateOutput : IOutput
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

            using(var fileStream = new FileStream("output\\csv_Rate.csv", FileMode.Create))
            {
                Result baseResult = results.Find(f=>f.Name == Adapters.NoContainerAdapter.PACKAGENAME);
                using(var writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine("Container,Version,Singleton,Transient,Combined,Complex,Property,Generics,IEnumerable,Conditional,Child,Interception");
                    foreach(Result result in this.results)
                    {
                        // write container name and resolve times
                        string s = String.Format(
                            "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                            result.Name,
                            result.Version,
                            CalcRate(result.SingletonTime, baseResult.SingletonTime),
                            CalcRate(result.TransientTime, baseResult.TransientTime),
                            CalcRate(result.CombinedTime , baseResult.CombinedTime),
                            CalcRate(result.ComplexTime , baseResult.ComplexTime),
                            CalcRate(result.PropertyInjectionTime, baseResult.PropertyInjectionTime),
                            CalcRate(result.GenericTime, baseResult.GenericTime),
                            CalcRate(result.MultipleImport, baseResult.MultipleImport),
                            CalcRate(result.ConditionalTime, baseResult.ConditionalTime),
                            CalcRate(result.ChildContainerTime, baseResult.ChildContainerTime),
                            CalcRate(result.InterceptionTime, baseResult.InterceptionTime)
                            );
                        writer.WriteLine(s);
                    }

                }
            }
        }

        private string CalcRate(long? val, long? baseValue)
        {
            if(!val.HasValue  ||  !baseValue.HasValue)
                return "-";
            if(baseValue.Value == 0)
                return "NaN";

            double rate = (double)val.Value / baseValue.Value;
            return rate.ToString("0.000");
        }

    }
}
