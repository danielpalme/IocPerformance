using System;

namespace IocPerformance.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Start()
        {
            Console.WriteLine("Name        \tSingleton\tTransient\tCombined\t#.ctor Singleton\t#.ctor Transient\t#.ctor Combined");
        }

        public void Result(Result result)
        {
            Console.WriteLine(string.Format(
                "{0}\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t\t{5}\t\t\t\t{6}",
                result.Name + "             ".Substring(result.Name.Length - 1),
                result.SingletonTime,
                result.TransientTime,
                result.CombinedTime,
                result.SingletonInstances,
                result.TransientInstances,
                result.CombinedInstances));
        }

        public void Finish()
        {
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
