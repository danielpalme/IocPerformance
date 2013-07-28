using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IocPerformance.Output
{
    public class HtmlOutput : IOutput
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

            using (var fileStream = new FileStream("output\\result.txt", FileMode.Create))
            {
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write("<tr><th>Container</th><th>Singleton</th><th>Transient</th><th>Combined</th>");
                    writer.WriteLine("<th>Complex</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Interception</th></tr>");

                    foreach (var result in this.results)
                    {
                        writer.Write(
                            "<tr><th>{0}{1}{2}</th><t{3}>{4}</t{3}><t{5}>{6}</t{5}><t{7}>{8}</t{7}>",
                            result.Name,
                            string.IsNullOrEmpty(result.Version) ? string.Empty : " ",
                            result.Version,
                            result.SingletonTime == this.results.Skip(1).Min(r => r.SingletonTime) ? "h" : "d",
                            result.SingletonTime,
                            result.TransientTime == this.results.Skip(1).Min(r => r.TransientTime) ? "h" : "d",
                            result.TransientTime,
                            result.CombinedTime == this.results.Skip(1).Min(r => r.CombinedTime) ? "h" : "d",
                            result.CombinedTime);

                        writer.WriteLine(
									 "<t{0}>{1}</t{0}><t{2}>{3}</t{2}><t{4}>{5}</t{4}><t{6}>{7}</t{6}><t{8}>{9}</t{8}><t{10}>{11}</t{10}></tr>",
									 result.ComplexTime == this.results.Skip(1).Min(r => r.ComplexTime) ? "h" : "d",
									 result.ComplexTime,
									 result.PropertyInjectionTime == this.results.Skip(1).Min(r => r.PropertyInjectionTime) ? "h" : "d",
									 result.PropertyInjectionTime,
                            result.GenericTime == this.results.Skip(1).Min(r => r.GenericTime) ? "h" : "d",
                            result.GenericTime,
                            result.MultipleImport == this.results.Skip(1).Min(r => r.MultipleImport) ? "h" : "d",
                            result.MultipleImport,
                            result.ConditionalTime == this.results.Skip(1).Min(r => r.ConditionalTime) ? "h" : "d",
                            result.ConditionalTime,
                            result.InterceptionTime == this.results.Skip(1).Min(r => r.InterceptionTime) ? "h" : "d",
                            result.InterceptionTime);
                    }
                }
            }
        }
    }
}
