using System;

namespace IocPerformance.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Start()
        {
            Console.WriteLine("Name        \tSingleton\tTransient\tCombined\tInterception\t#.ctor Singleton\t#.ctor Transient\t#.ctor Combined\t#.ctor Interception");
        }

        public void Result(Result result)
        {
            Console.WriteLine(string.Format(
                "{0}\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t\t{6}\t\t\t\t{7}\t\t\t\t{8}",
                result.Name + "             ".Substring(result.Name.Length - 1),
                result.SingletonTime,
                result.TransientTime,
                result.CombinedTime,
                result.InterceptionTime.HasValue ? result.InterceptionTime.Value.ToString() : string.Empty,
                result.SingletonInstances,
                result.TransientInstances,
                result.CombinedInstances,
                result.InterceptionInstances));
        }

        public void Finish()
        {
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
