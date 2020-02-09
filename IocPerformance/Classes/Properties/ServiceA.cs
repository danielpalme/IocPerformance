using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    public interface IServiceA
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceA))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceA))]
    [MEF2Attr.Shared]
    public class ServiceA : IServiceA
    {
        [Stiletto.Inject]
        public ServiceA()
        {
        }
    }
}
