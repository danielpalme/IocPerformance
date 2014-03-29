using System;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.Child
{
    public class ScopedCombined1 : ICombined1
    {
        public ScopedCombined1(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException("transient");
            }

            if (singleton == null)
            {
                throw new ArgumentNullException("singleton");
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }

    public class ScopedCombined2 : ICombined2
    {
        public ScopedCombined2(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException("transient");
            }

            if (singleton == null)
            {
                throw new ArgumentNullException("singleton");
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }


    public class ScopedCombined3 : ICombined3
    {
        public ScopedCombined3(ITransient1 transient, ISingleton1 singleton)
        {
            if (transient == null)
            {
                throw new ArgumentNullException("transient");
            }

            if (singleton == null)
            {
                throw new ArgumentNullException("singleton");
            }

            if (!(transient is ScopedTransient))
            {
                throw new ArgumentException("transient should be of type ScopedTransient");
            }

            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }
}
