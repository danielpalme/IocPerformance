using IocPerformance.Interception;
using IocPerformance.Interception.Cauldron;
using System.Diagnostics;

namespace IocPerformance.Classes.Standard
{
    public interface ICalculator1
    {
        int Add(int first, int second);
    }

    public interface ICalculator2
    {
        int Add(int first, int second);
    }

    public interface ICalculator3
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

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }

    [UnityInterceptionLogger]
    public class Calculator2 : ICalculator2
    {
        private static int counter;

        public Calculator2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }

    [UnityInterceptionLogger]
    public class Calculator3 : ICalculator3
    {
        private static int counter;

        public Calculator3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public virtual int Add(int first, int second) => first + second;
    }

    #region No Interceptor

    public class NoCalculator1 : Calculator1
    {
        private static int counter;

        public NoCalculator1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public override int Add(int first, int second)
        {
            var args = string.Join(", ", new string[] { first.ToString(), second.ToString() });
            Debug.WriteLine(string.Format("No: {0}({1})", nameof(Add), args));
            return base.Add(first, second);
        }
    }

    public class NoCalculator2 : Calculator2
    {
        private static int counter;

        public NoCalculator2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public override int Add(int first, int second)
        {
            var args = string.Join(", ", new string[] { first.ToString(), second.ToString() });
            Debug.WriteLine(string.Format("No: {0}({1})", nameof(Add), args));
            return base.Add(first, second);
        }
    }

    public class NoCalculator3 : Calculator3
    {
        private static int counter;

        public NoCalculator3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public override int Add(int first, int second)
        {
            var args = string.Join(", ", new string[] { first.ToString(), second.ToString() });
            Debug.WriteLine(string.Format("No: {0}({1})", nameof(Add), args));
            return base.Add(first, second);
        }
    }

    #endregion No Interceptor
}