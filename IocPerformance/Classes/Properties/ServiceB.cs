using MEFAttr = System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ServiceB))]
    public interface IServiceB
    {
    }

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
