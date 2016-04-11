using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
    public class ScopedCombined1 : ICombined1
    {
        private static int counter;

        public ScopedCombined1(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
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

    public class ScopedCombined2 : ICombined2
    {
        private static int counter;

        public ScopedCombined2(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
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

    public class ScopedCombined3 : ICombined3
    {
        private static int counter;

        public ScopedCombined3(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException(nameof(transient));
            }

            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
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
}
