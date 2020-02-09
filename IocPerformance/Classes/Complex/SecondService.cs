using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISecondService
    {
    }

    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(ISecondService))]
    public class SecondService : ISecondService
    {
        [Stiletto.Inject]
        public SecondService()
        {
        }
    }
}
