using MEFAttr = System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceC))]
    public interface IServiceC
    {
    }

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
