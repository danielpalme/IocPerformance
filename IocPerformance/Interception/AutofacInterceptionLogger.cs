using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;

namespace IocPerformance.Interception
{
    public class AutofacInterceptionLogger : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // Perform logging here, e.g.:
            var args = string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine(string.Format("Autofac: {0}({1})", invocation.Method.Name, args));

            invocation.Proceed();
        }
    }
}
