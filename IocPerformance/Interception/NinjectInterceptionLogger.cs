using System.Diagnostics;
using System.Linq;
using Ninject.Extensions.Interception;

namespace IocPerformance.Interception
{
    public class NinjectInterceptionLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // Perform logging here, e.g.:
            var args = string.Join(", ", invocation.Request.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine(string.Format("Ninject: {0}({1})", invocation.Request.Method.Name, args));

            invocation.Proceed();
        }
    }
}
