using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace IocPerformance.Interception
{
    public class UnityInterceptionLoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new UnityInterceptionLogger();
        }
    }
}
