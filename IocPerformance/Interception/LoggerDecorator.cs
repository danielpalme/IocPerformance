using System.Diagnostics;

namespace IocPerformance.Interception
{
    public class LoggerDecorator : ICalculator
    {
        private readonly ICalculator calculator;

        public LoggerDecorator(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public int Add(int first, int second)
        {
            // Perform logging here, e.g.:
            var args = first + ", " + second;
            Trace.WriteLine(string.Format("Decorator: {0}({1})", "Add", args));

            return this.calculator.Add(first, second);
        }
    }
}
