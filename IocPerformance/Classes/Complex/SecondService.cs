using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(SecondService))]
    public interface ISecondService
    {
    }

    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISecondService))]
    [IfInjector.Singleton]
    public class SecondService : ISecondService
    {
        [Stiletto.Inject]
        public SecondService()
        {
        }
    }
}
