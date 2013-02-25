using System.Collections.Generic;

namespace IocPerformance.Output
{
    public class MultiOutput : IOutput
    {
        private readonly IEnumerable<IOutput> outputs;

        public void Start()
        {
            foreach (var output in this.outputs)
            {
                output.Start();
            }
        }

        public MultiOutput(IEnumerable<IOutput> outputs)
        {
            this.outputs = outputs;
        }

        public void Result(Result result)
        {
            foreach (var output in this.outputs)
            {
                output.Result(result);
            }
        }

        public void Finish()
        {
            foreach (var output in this.outputs)
            {
                output.Finish();
            }
        }
    }
}
