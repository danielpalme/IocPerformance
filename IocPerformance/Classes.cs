using System;
using System.ComponentModel.Composition;
using IocPerformance.Interception;

namespace IocPerformance
{
    public interface ISingleton
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton)), PartCreationPolicy(CreationPolicy.Shared)]
    public class Singleton : ISingleton
    {
        public static int Instances { get; set; }

        public Singleton()
        {
            Instances++;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface ITransient
    {
        void DoSomething();
    }

    [Export(typeof(ITransient)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class Transient : ITransient
    {
        public static int Instances { get; set; }

        public Transient()
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

    [Export(typeof(ICombined)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class Combined : ICombined
    {
        public static int Instances { get; set; }

        [ImportingConstructor]
        public Combined(ISingleton first, ITransient second)
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

    public interface ICalculator
    {
        int Add(int first, int second);
    }

    [UnityInterceptionLogger]
    public class Calculator : ICalculator
    {
        public static int Instances { get; set; }

        public Calculator()
        {
            Instances++;
        }

        public virtual int Add(int first, int second)
        {
            return first + second;
        }
    }
}
