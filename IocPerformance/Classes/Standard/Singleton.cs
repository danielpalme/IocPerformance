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

    [IfInjector.ImplementedBy(typeof(Singleton2))]
    public interface ISingleton2
    {
        void DoSomething();
    }

    [IfInjector.ImplementedBy(typeof(Singleton3))]
    public interface ISingleton3
    {
        void DoSomething();
    }

    [Cauldron.Activator.Component(typeof(ISingleton1), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [Export(typeof(ISingleton1)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton1)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton1 : ISingleton1
    {
        private static int counter;

        [Stiletto.Inject]
        public Singleton1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    [Cauldron.Activator.Component(typeof(ISingleton2), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [Export(typeof(ISingleton2)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton2)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton2 : ISingleton2
    {
        private static int counter;

        [Stiletto.Inject]
        public Singleton2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    [Cauldron.Activator.Component(typeof(ISingleton3), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [Export(typeof(ISingleton3)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISingleton3)), MEF2Attr.Shared]
    [Stiletto.Singleton]
    [IfInjector.Singleton]
    public class Singleton3 : ISingleton3
    {
        private static int counter;

        [Stiletto.Inject]
        public Singleton3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }
}
