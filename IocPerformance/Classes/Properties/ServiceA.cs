using MEFAttr = System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceA))]
    public interface IServiceA
    {
    }

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
