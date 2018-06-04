using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Combined1))]
    public interface ICombined1
    {
        void DoSomething();
    }

    [IfInjector.ImplementedBy(typeof(Combined2))]
    public interface ICombined2
    {
        void DoSomething();
    }

    [IfInjector.ImplementedBy(typeof(Combined3))]
    public interface ICombined3
    {
        void DoSomething();
    }

    [Export(typeof(ICombined1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined1))]
    public class Combined1 : ICombined1
    {
        protected static int counter;

        protected Combined1()
        {
        }

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined1(ISingleton1 first, ITransient1 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    [Export(typeof(ICombined2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined2))]
    public class Combined2 : ICombined2
    {
        protected static int counter;

        protected Combined2()
        {
        }

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined2(ISingleton2 first, ITransient2 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    [Export(typeof(ICombined3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined3))]
    public class Combined3 : ICombined3
    {
        protected static int counter;

        protected Combined3()
        {
        }

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined3(ISingleton3 first, ITransient3 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
     */

    [Cauldron.Activator.Component(typeof(ICombined1))]
    public class CauldronCombined1 : Combined1
    {
        [Cauldron.Activator.Inject] private ISingleton1 first;
        [Cauldron.Activator.Inject] private ITransient1 second;

        [Cauldron.Activator.ComponentConstructor]
        internal CauldronCombined1() : base()
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }


    [Cauldron.Activator.Component(typeof(ICombined2))]
    public class CauldronCombined2 : Combined2
    {
        [Cauldron.Activator.Inject] private ISingleton2 first;
        [Cauldron.Activator.Inject] private ITransient2 second;

        [Cauldron.Activator.ComponentConstructor]
        internal CauldronCombined2() : base()
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    [Cauldron.Activator.Component(typeof(ICombined3))]
    public class CauldronCombined3 : Combined3
    {
        [Cauldron.Activator.Inject] private ISingleton3 first;
        [Cauldron.Activator.Inject] private ITransient3 second;

        [Cauldron.Activator.ComponentConstructor]
        internal CauldronCombined3() : base()
        {
            if (first == null)
            {
                throw new ArgumentNullException(nameof(first));
            }

            if (second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    #endregion
}
