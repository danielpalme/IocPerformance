using System;
using System.ComponentModel.Composition;

namespace IocPerformance
{
    public interface ITransient
    {
        void DoSomething();
    }

    [Export(typeof(ITransient)), PartCreationPolicy(CreationPolicy.Shared)]
    public class Transient : ITransient
    {
        public static int Instances { get; set; }

        public Transient()
        {
            Instances++;
        }

        public void DoSomething()
        {
            Console.WriteLine("Hello");
        }
    }

    public interface ISingleton
    {
        void DoSomething();
    }

    [Export(typeof(ISingleton)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class Singleton : ISingleton
    {
        public static int Instances { get; set; }

        public Singleton()
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
        public Combined(ITransient first, ISingleton second)
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
