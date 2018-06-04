using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Transient1))]
    public interface ITransient1
    {
        void DoSomething();
    }

    [IfInjector.ImplementedBy(typeof(Transient2))]
    public interface ITransient2
    {
        void DoSomething();
    }

    [IfInjector.ImplementedBy(typeof(Transient3))]
    public interface ITransient3
    {
        void DoSomething();
    }

    [Cauldron.Activator.Component(typeof(ITransient1))]
    [Export(typeof(ITransient1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient1))]
    public class Transient1 : ITransient1
    {
        private static int counter;

        [Stiletto.Inject]
        public Transient1()
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
            Console.WriteLine("World");
        }
    }

    [Cauldron.Activator.Component(typeof(ITransient2))]
    [Export(typeof(ITransient2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient2))]
    public class Transient2 : ITransient2
    {
        private static int counter;

        [Stiletto.Inject]
        public Transient2()
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
            Console.WriteLine("World");
        }
    }

    [Cauldron.Activator.Component(typeof(ITransient3))]
    [Export(typeof(ITransient3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ITransient3))]
    public class Transient3 : ITransient3
    {
        private static int counter;

        [Stiletto.Inject]
        public Transient3()
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
            Console.WriteLine("World");
        }
    }
}
