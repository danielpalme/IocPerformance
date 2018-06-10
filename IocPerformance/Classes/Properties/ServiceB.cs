using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceB))]
    public interface IServiceB
    {
    }

    [Cauldron.Activator.Component(typeof(IServiceB), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [MEFAttr.ExportAttribute(typeof(IServiceB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceB))]
    [MEF2Attr.Shared]
    [IfInjector.Singleton]
    public class ServiceB : IServiceB
    {
        [Stiletto.Inject]
        public ServiceB()
        {
        }
    }
}
