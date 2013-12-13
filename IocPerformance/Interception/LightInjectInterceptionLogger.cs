namespace IocPerformance.Interception
{
    using System.Diagnostics;
    using System.Linq;

    using LightInject.Interception;

    public class LightInjectInterceptionLogger : IInterceptor
    {
        public object Invoke(IInvocationInfo invocationInfo)
        {
            var args = string.Join(", ", invocationInfo.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Debug.WriteLine("LightInject: {0}({1})", invocationInfo.Method, args);
            return invocationInfo.Proceed();
        }
    }
}