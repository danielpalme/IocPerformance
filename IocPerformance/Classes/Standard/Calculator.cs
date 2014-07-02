using IocPerformance.Interception;

namespace IocPerformance.Classes.Standard
{
    public interface ICalculator1
    {
        int Add(int first, int second);
    }

    [UnityInterceptionLogger]
    public class Calculator1 : ICalculator1
    {
        private static int counter;

        public Calculator1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public virtual int Add(int first, int second)
        {
            return first + second;
        }
    }

    public interface ICalculator2
    {
        int Add(int first, int second);
    }

    [UnityInterceptionLogger]
    public class Calculator2 : ICalculator2
    {
        private static int counter;

        public Calculator2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public virtual int Add(int first, int second)
        {
            return first + second;
        }
    }

    public interface ICalculator3
    {
        int Add(int first, int second);
    }

    [UnityInterceptionLogger]
    public class Calculator3 : ICalculator3
    {
        private static int counter;

        public Calculator3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }

        public virtual int Add(int first, int second)
        {
            return first + second;
        }
    }
}
