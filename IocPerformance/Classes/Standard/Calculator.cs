using IocPerformance.Interception;
using IocPerformance.Interception.Cauldron;

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

    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
     */
    
    [Cauldron.Activator.Component(typeof(ICalculator1))]
    public class CauldronCalculator1 : Calculator1
    {
        [CauldronLogger]
        public override int Add(int first, int second) => base.Add(first, second);
    }

    [Cauldron.Activator.Component(typeof(ICalculator2))]
    public class CauldronCalculator2 : Calculator2
    {
        [CauldronLogger]
        public override int Add(int first, int second) => base.Add(first, second);
    }

    [Cauldron.Activator.Component(typeof(ICalculator3))]
    public class CauldronCalculator3 : Calculator3
    {
        [CauldronLogger]
        public override int Add(int first, int second) => base.Add(first, second);
    }

    #endregion
}
