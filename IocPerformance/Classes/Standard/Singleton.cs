using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Singleton1))]
    public interface ISingleton1
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton1)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton1)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton1 : ISingleton1
    {
        [Stiletto.Inject]
        public Singleton1()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    [IfInjector.ImplementedBy(typeof(Singleton2))]
    public interface ISingleton2
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton2)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton2)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton2 : ISingleton2
    {
        [Stiletto.Inject]
        public Singleton2()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    [IfInjector.ImplementedBy(typeof(Singleton3))]
    public interface ISingleton3
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton3)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton3)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton3 : ISingleton3
    {
        [Stiletto.Inject]
        public Singleton3()
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
