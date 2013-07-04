using System.Diagnostics;
using System.Linq;
using LinFu.AOP.Interfaces;

namespace IocPerformance.Interception
{
    public class LinfuInterceptionLogger : IInterceptor
    {
        public object Intercept(IInvocationInfo info)
        {
            var args = string.Join(", ", info.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("Linfu: {0}({1})", info.TargetMethod.Name, args));

            return info.TargetMethod.Invoke(info.Target, info.Arguments);
        }
    }

    /* public class LinfuInterceptionLogger : IInvokeWrapper
    {
        private readonly object target;

        public LinfuInterceptionLogger(object target)
        {
            this.target = target;
        }

        public void BeforeInvoke(IInvocationInfo info)
        {
            var args = string.Join(", ", info.Arguments.Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("Linfu: {0}({1})", info.TargetMethod.Name, args));
        }

        public object DoInvoke(IInvocationInfo info)
        {
            return info.TargetMethod.Invoke(this.target, info.Arguments);
        }

        public void AfterInvoke(IInvocationInfo info, object returnValue)
        {
        }
    } */
}
