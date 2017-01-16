using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace IocPerformance.Interception
{
    public class UnityInterceptionLoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container) => new UnityInterceptionLogger();
    }
}
