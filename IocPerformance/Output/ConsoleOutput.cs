using System;

namespace IocPerformance.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Start()
        {
            Console.WriteLine("Name        \tSingleton\tTransient\tCombined\tComplex\t\tGeneric\t\tMultiple\tConditional\tInterception");
        }

        public void Result(Result result)
        {
            Console.WriteLine(string.Format(
                "{0}\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}",
                result.Name + "             ".Substring(result.Name.Length - 1),
                result.SingletonTime,
                result.TransientTime,
                result.CombinedTime,
					 result.ComplexTime,
					 result.GenericTime.HasValue ? result.GenericTime.Value.ToString() : "    ",
					 result.MultipleImport.HasValue ? result.MultipleImport.Value.ToString() : "    ",
					 result.ConditionalTime.HasValue ? result.ConditionalTime.Value.ToString() : "    ",
					 result.InterceptionTime.HasValue ? result.InterceptionTime.Value.ToString() : "    "));
        }

        public void Finish()
        {
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
