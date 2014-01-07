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
                    writer.WriteLine("<th>Complex</th><th>Property</th><th>Generics</th><th>IEnumerable</th><th>Conditional</th><th>Child Container</th><th>Interception</th></tr>");

                    foreach (var result in this.results)
                    {
                        writer.Write(
                            "<tr><th>{0}</th><t{1}>{2}</t{1}><t{3}>{4}</t{3}><t{5}>{6}</t{5}><t{7}>{8}</t{7}>",
                            GetName(result),
                            result.SingletonTime == this.results.Skip(1).Min(r => r.SingletonTime) ? "h" : "d",
                            result.SingletonTime,
                            result.TransientTime == this.results.Skip(1).Min(r => r.TransientTime) ? "h" : "d",
                            result.TransientTime,
                            result.CombinedTime == this.results.Skip(1).Min(r => r.CombinedTime) ? "h" : "d",
                            result.CombinedTime,
                            result.ComplexTime == this.results.Skip(1).Min(r => r.ComplexTime) ? "h" : "d",
                            result.ComplexTime);

                        writer.WriteLine(
                            "<t{0}>{1}</t{0}><t{2}>{3}</t{2}><t{4}>{5}</t{4}><t{6}>{7}</t{6}><t{8}>{9}</t{8}><t{10}>{11}</t{10}></tr>",
                            result.PropertyInjectionTime == this.results.Skip(1).Min(r => r.PropertyInjectionTime) ? "h" : "d",
                            result.PropertyInjectionTime,
                            result.GenericTime == this.results.Skip(1).Min(r => r.GenericTime) ? "h" : "d",
                            result.GenericTime,
                            result.MultipleImport == this.results.Skip(1).Min(r => r.MultipleImport) ? "h" : "d",
                            result.MultipleImport,
                            result.ConditionalTime == this.results.Skip(1).Min(r => r.ConditionalTime) ? "h" : "d",
                            result.ConditionalTime,
                            result.ChildContainerTime == this.results.Skip(1).Min(r => r.ChildContainerTime) ? "h" : "d",
                            result.ChildContainerTime,
                            result.InterceptionTime == this.results.Skip(1).Min(r => r.InterceptionTime) ? "h" : "d",
                            result.InterceptionTime);
                    }
                }
            }
        }

        private static string GetName(Result result)
        {
            string name = string.Format(
                "{0}{1}{2}",
                result.Name,
                string.IsNullOrEmpty(result.Version) ? string.Empty : " ",
                result.Version);

            if (!string.IsNullOrEmpty(result.Url))
            {
                name = string.Format("<a href=\"{0}\">{1}</a>", result.Url, name);
            }

            return name;
        }
    }
}
