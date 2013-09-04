using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceC))]
    public interface IServiceC
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [IfInjector.Singleton]
    public class ServiceC : IServiceC
    {
        [Stiletto.Inject]
        public ServiceC()
        {
        }
    }
}
