using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IFirstService
    {
    }

    [Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IFirstService))]
    public class FirstService : IFirstService
    {
        [Stiletto.Inject]
        public FirstService()
        {
        }
    }
}
