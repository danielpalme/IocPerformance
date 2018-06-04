using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceC))]
    public interface IServiceC
    {
    }

    [Cauldron.Activator.Component(typeof(IServiceC), Cauldron.Activator.FactoryCreationPolicy.Singleton)]
    [MEFAttr.ExportAttribute(typeof(IServiceC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceC))]
    [MEF2Attr.Shared]
    [IfInjector.Singleton]
    public class ServiceC : IServiceC
    {
        [Stiletto.Inject]
        public ServiceC()
        {
        }
    }
}
