using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    public interface ISingleton
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton)), PartCreationPolicy(CreationPolicy.Shared)]
    [Stiletto.Singleton]
    public class Singleton : ISingleton
    {
        [Stiletto.Inject]
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
