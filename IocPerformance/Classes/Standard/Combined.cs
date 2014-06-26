using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Combined1))]
    public interface ICombined1
    {
        void DoSomething();
    }

    [Export(typeof(ICombined1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined1))]
    public class Combined1 : ICombined1
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined1(ISingleton1 first, ITransient1 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    [IfInjector.ImplementedBy(typeof(Combined2))]
    public interface ICombined2
    {
        void DoSomething();
    }

    [Export(typeof(ICombined2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined2))]
    public class Combined2 : ICombined2
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined2(ISingleton2 first, ITransient2 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    [IfInjector.ImplementedBy(typeof(Combined3))]
    public interface ICombined3
    {
        void DoSomething();
    }

    [Export(typeof(ICombined3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined3))]
    public class Combined3 : ICombined3
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined3(ISingleton3 first, ITransient3 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }
}
