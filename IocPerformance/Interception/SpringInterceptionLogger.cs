using System;
using System.Diagnostics;
using System.Linq;
using AopAlliance.Intercept;

namespace IocPerformance.Interception
{
    [Serializable]
    public class SpringInterceptionLogger : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            // Perform logging here, e.g.:
            var args = string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("Spring.NET: {0}({1})", invocation.Method.Name, args));

            return invocation.Proceed();
        }
    }
}
