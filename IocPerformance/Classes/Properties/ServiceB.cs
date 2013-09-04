using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceB))]
    public interface IServiceB
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [IfInjector.Singleton]
    public class ServiceB : IServiceB
    {
        [Stiletto.Inject]
        public ServiceB()
        {
        }
    }
}
