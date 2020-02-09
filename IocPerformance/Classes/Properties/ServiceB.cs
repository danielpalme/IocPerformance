using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    public interface IServiceB
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceB))]
    [MEF2Attr.Shared]
    public class ServiceB : IServiceB
    {
        [Stiletto.Inject]
        public ServiceB()
        {
        }
    }
}
