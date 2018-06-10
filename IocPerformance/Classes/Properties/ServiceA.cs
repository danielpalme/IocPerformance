using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceA))]
    public interface IServiceA
    {
    }

    [Cauldron.Activator.Component(typeof(IServiceA), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [MEFAttr.ExportAttribute(typeof(IServiceA))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceA))]
    [MEF2Attr.Shared]
    [IfInjector.Singleton]
    public class ServiceA : IServiceA
    {
        [Stiletto.Inject]
        public ServiceA()
        {
        }
    }
}
