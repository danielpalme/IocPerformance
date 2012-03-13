using System;

namespace IocPerformance
{
    public interface IInterface1
    {
        void DoSomething();
    }

    public class Implementation1 : IInterface1
    {
        public static int Instances { get; set; }

        public Implementation1()
        {
            Instances++;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface IInterface2
    {
        void DoSomething();
    }

    public class Implementation2 : IInterface2
    {
        public static int Instances { get; set; }

        public Implementation2()
        {
            Instances++;
        }

        public void DoSomething()
        {
            Console.WriteLine("World");
        }
    }

    public interface ICombined
    {
        void DoSomething();
    }

    public class Combined : ICombined
    {
        public static int Instances { get; set; }

        public Combined(IInterface1 first, IInterface2 second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            Instances++;
        }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }
}
