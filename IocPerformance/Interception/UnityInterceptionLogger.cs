using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IocPerformance.Interception
{
    public class UnityInterceptionLogger : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);

            var args = string.Join(", ", input.Arguments.Cast<object>().Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("Unity: {0}({1})", input.MethodBase.Name, args));

            return result;
        }
    }
}
