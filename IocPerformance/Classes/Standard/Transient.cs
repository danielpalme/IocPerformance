using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Transient1))]
    public interface ITransient1
    {
        void DoSomething();
    }

    [Export(typeof(ITransient1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient1))]
    public class Transient1 : ITransient1
    {
        [Stiletto.Inject]
        public Transient1()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("World");
        }
    }

    [IfInjector.ImplementedBy(typeof(Transient2))]
    public interface ITransient2
    {
        void DoSomething();
    }

    [Export(typeof(ITransient2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient2))]
    public class Transient2 : ITransient2
    {
        [Stiletto.Inject]
        public Transient2()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("World");
        }
    }

    [IfInjector.ImplementedBy(typeof(Transient3))]
    public interface ITransient3
    {
        void DoSomething();
    }

    [Export(typeof(ITransient3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient3))]
    public class Transient3 : ITransient3
    {
        [Stiletto.Inject]
        public Transient3()
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
