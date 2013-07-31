using System.Diagnostics;
using System.Linq;
using HaveBox.HaveBoxProxy;

namespace IocPerformance.Interception
{
    public class HaveBoxInterceptionLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // Perform logging here, e.g.:
            var args = string.Join(", ", invocation.Args.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine(string.Format("HaveBox: {0}({1})", invocation.Method.Name, args));

            invocation.Proceed();
        }
    }
}
