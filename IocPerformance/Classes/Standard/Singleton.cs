using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    public interface ISingleton
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton)), PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton : ISingleton
    {
        public Singleton()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }
}
