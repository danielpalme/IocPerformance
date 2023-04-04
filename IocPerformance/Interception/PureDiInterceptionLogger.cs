using System.Diagnostics;
using System.Linq;
using Castle.DynamicProxy;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace IocPerformance.Interception
{
    internal sealed class PureDiInterceptionLogger: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Debug.WriteLine("Pure.DI: {0}({1})", invocation.Method, string.Join(", ", invocation.Arguments.Select(x => (x ?? string.Empty).ToString())));
            invocation.Proceed();
        }
    }
}