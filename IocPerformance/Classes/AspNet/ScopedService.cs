using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IocPerformance.Classes.AspNet
{
    public interface IScopedService1
    {
        void DoSomething();
    }

    public class ScopedService1 : IScopedService1
    {
        private static int counter;

        public ScopedService1()
        {
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

    public interface IScopedService2
    {
        void DoSomething();
    }

    public class ScopedService2 : IScopedService2
    {
        private static int counter;

        public ScopedService2()
        {
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

    public interface IScopedService3
    {
        void DoSomething();
    }

    public class ScopedService3 : IScopedService3
    {
        private static int counter;

        public ScopedService3()
        {
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

    public interface IScopedService4
    {
        void DoSomething();
    }

    public class ScopedService4 : IScopedService4
    {
        private static int counter;

        public ScopedService4()
        {
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

    public interface IScopedService5
    {
        void DoSomething();
    }

    public class ScopedService5 : IScopedService5
    {
        private static int counter;

        public ScopedService5()
        {
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
