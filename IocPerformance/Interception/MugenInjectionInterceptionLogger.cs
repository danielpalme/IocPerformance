using System;
using System.Diagnostics;
using System.Linq;
using MugenInjection.Interception.Interface;

namespace IocPerformance.Interception
{
    public class MugenInjectionInterceptionLogger : IInterceptorProcess
    {
        #region Implementation of IInterceptorProcess

        public void InterceptMethod(IMethodInterceptor methodInterceptor)
        {
            // Perform logging here, e.g.:
            string args = string.Join(", ",
                methodInterceptor.InputParameters.Select(x => (x ?? string.Empty).ToString()));
            Trace.WriteLine(string.Format("Mugen: {0}({1})", methodInterceptor.Member.Name, args));
            
            methodInterceptor.ProcessInTarget();
        }

        public void InterceptGetProperty(IPropertyGetInterceptor propertyGetInterceptor)
        {
            throw new NotSupportedException();
        }

        public void InterceptSetProperty(IPropertySetInterceptor propertySetInterceptor)
        {
            throw new NotSupportedException();
        }

        public void InterceptAddEvent(IEventAddInterceptor eventAddInterceptor)
        {
            throw new NotSupportedException();
        }

        public void InterceptRemoveEvent(IEventRemoveInterceptor eventRemoveInterceptor)
        {
            throw new NotSupportedException();
        }

        public int Priority { get; private set; }

        #endregion
    }
}