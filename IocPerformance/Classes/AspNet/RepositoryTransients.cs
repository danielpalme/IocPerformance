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

    public class RepositoryTransient1 : IRepositoryTransient1
    {
        private static int counter;

        public RepositoryTransient1(ISingleton1 singleton, IScopedService scopedService)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService == null)
            {
                throw new ArgumentNullException(nameof(scopedService));
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

        public RepositoryTransient2(ISingleton1 singleton, IScopedService scopedService)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService == null)
            {
                throw new ArgumentNullException(nameof(scopedService));
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

        public RepositoryTransient3(ISingleton1 singleton, IScopedService scopedService)
        {
            if (singleton == null)
            {
                throw new ArgumentNullException(nameof(singleton));
            }

            if (scopedService == null)
            {
                throw new ArgumentNullException(nameof(scopedService));
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
