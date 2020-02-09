using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    public interface IServiceC
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    [MEF2Attr.ExportAttribute(typeof(IServiceC))]
    [MEF2Attr.Shared]
    public class ServiceC : IServiceC
    {
        [Stiletto.Inject]
        public ServiceC()
        {
        }
    }
}
