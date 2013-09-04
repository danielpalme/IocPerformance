using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Transient))]
    public interface ITransient
    {
        void DoSomething();
    }

    [Export(typeof(ITransient)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient : ITransient
    {
        [Stiletto.Inject]
        public Transient()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("World");
        }
    }
}
