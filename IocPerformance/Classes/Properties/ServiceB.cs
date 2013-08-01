using MEFAttr = System.ComponentModel.Composition;

namespace IocPerformance.Classes.Properties
{
    public interface IServiceB
    {
    }

    [MEFAttr.ExportAttribute(typeof(IServiceB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.Shared)]
    public class ServiceB : IServiceB
    {
        [Stiletto.Inject]
        public ServiceB()
        {

        }
    }
}
