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
        public Calculator1()
        {
            Instances++;
        }

        public static int Instances { get; set; }

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
        public Calculator2()
        {
            Instances++;
        }

        public static int Instances { get; set; }

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
        public Calculator3()
        {
            Instances++;
        }

        public static int Instances { get; set; }

        public virtual int Add(int first, int second)
        {
            return first + second;
        }
    }
}
