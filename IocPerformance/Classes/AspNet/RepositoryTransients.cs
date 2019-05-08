using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IocPerformance.Classes.Standard;

namespace IocPerformance.Classes.AspNet
{
    public interface IRepositoryTransient1
    {
        void DoSomething();
    }

    public interface IRepositoryTransient2
    {
        void DoSomething();
    }

    public interface IRepositoryTransient3
    {
        void DoSomething();
    }

    public interface IRepositoryTransient4
    {
        void DoSomething();
    }

    public interface IRepositoryTransient5
    {
        void DoSomething();
    }

    public class RepositoryTransient1 : IRepositoryTransient1
    {
        private static int counter;

        public RepositoryTransient1(ISingleton1 singleton, IScopedService1 scopedService1, IScopedService2 scopedService2, IScopedService3 scopedService3, IScopedService4 scopedService4, IScopedService5 scopedService5)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService1 == null)
            {
                throw new ArgumentNullException(nameof(scopedService1));
            }

            if (scopedService2 == null)
            {
                throw new ArgumentNullException(nameof(scopedService2));
            }

            if (scopedService3 == null)
            {
                throw new ArgumentNullException(nameof(scopedService3));
            }

            if (scopedService4 == null)
            {
                throw new ArgumentNullException(nameof(scopedService4));
            }

            if (scopedService5 == null)
            {
                throw new ArgumentNullException(nameof(scopedService5));
            }

            Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
        
        public void DoSomething()
        {
        }
    }

    public class RepositoryTransient2 : IRepositoryTransient2
    {
        private static int counter;

        public RepositoryTransient2(ISingleton1 singleton, IScopedService1 scopedService1, IScopedService2 scopedService2, IScopedService3 scopedService3, IScopedService4 scopedService4, IScopedService5 scopedService5)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService1 == null)
            {
                throw new ArgumentNullException(nameof(scopedService1));
            }

            if (scopedService2 == null)
            {
                throw new ArgumentNullException(nameof(scopedService2));
            }

            if (scopedService3 == null)
            {
                throw new ArgumentNullException(nameof(scopedService3));
            }

            if (scopedService4 == null)
            {
                throw new ArgumentNullException(nameof(scopedService4));
            }

            if (scopedService5 == null)
            {
                throw new ArgumentNullException(nameof(scopedService5));
            }

            Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
        }
    }

    public class RepositoryTransient3 : IRepositoryTransient3
    {
        private static int counter;

        public RepositoryTransient3(ISingleton1 singleton, IScopedService1 scopedService1, IScopedService2 scopedService2, IScopedService3 scopedService3, IScopedService4 scopedService4, IScopedService5 scopedService5)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService1 == null)
            {
                throw new ArgumentNullException(nameof(scopedService1));
            }

            if (scopedService2 == null)
            {
                throw new ArgumentNullException(nameof(scopedService2));
            }

            if (scopedService3 == null)
            {
                throw new ArgumentNullException(nameof(scopedService3));
            }

            if (scopedService4 == null)
            {
                throw new ArgumentNullException(nameof(scopedService4));
            }

            if (scopedService5 == null)
            {
                throw new ArgumentNullException(nameof(scopedService5));
            }

            Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
        }
    }

    public class RepositoryTransient4 : IRepositoryTransient4
    {
        private static int counter;

        public RepositoryTransient4(ISingleton1 singleton, IScopedService1 scopedService1, IScopedService2 scopedService2, IScopedService3 scopedService3, IScopedService4 scopedService4, IScopedService5 scopedService5)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService1 == null)
            {
                throw new ArgumentNullException(nameof(scopedService1));
            }

            if (scopedService2 == null)
            {
                throw new ArgumentNullException(nameof(scopedService2));
            }

            if (scopedService3 == null)
            {
                throw new ArgumentNullException(nameof(scopedService3));
            }

            if (scopedService4 == null)
            {
                throw new ArgumentNullException(nameof(scopedService4));
            }

            if (scopedService5 == null)
            {
                throw new ArgumentNullException(nameof(scopedService5));
            }

            Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
        }
    }

    public class RepositoryTransient5 : IRepositoryTransient5
    {
        private static int counter;

        public RepositoryTransient5(ISingleton1 singleton, IScopedService1 scopedService1, IScopedService2 scopedService2, IScopedService3 scopedService3, IScopedService4 scopedService4, IScopedService5 scopedService5)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService1 == null)
            {
                throw new ArgumentNullException(nameof(scopedService1));
            }

            if (scopedService2 == null)
            {
                throw new ArgumentNullException(nameof(scopedService2));
            }

            if (scopedService3 == null)
            {
                throw new ArgumentNullException(nameof(scopedService3));
            }

            if (scopedService4 == null)
            {
                throw new ArgumentNullException(nameof(scopedService4));
            }

            if (scopedService5 == null)
            {
                throw new ArgumentNullException(nameof(scopedService5));
            }

            Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
        }
    }
}
