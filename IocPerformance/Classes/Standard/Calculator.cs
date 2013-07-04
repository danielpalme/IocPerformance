using IocPerformance.Interception;

namespace IocPerformance.Classes.Standard
{
    public interface ICalculator
    {
        int Add(int first, int second);
    }

    [UnityInterceptionLogger]
    public class Calculator : ICalculator
    {
        public Calculator()
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
