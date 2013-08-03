using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    public interface IServiceA
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceA))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    public class ServiceA : IServiceA
    {
        [Stiletto.Inject]
        public ServiceA()
        {
        }
    }
}
