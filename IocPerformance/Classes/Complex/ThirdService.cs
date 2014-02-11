using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(ThirdService))]
    public interface IThirdService
    {
    }

    [Export(typeof(IThirdService)), PartCreationPolicy(CreationPolicy.Shared)]
    [MEF2Attr.Export(typeof(IThirdService))]
    [IfInjector.Singleton]
    public class ThirdService : IThirdService
    {
        [Stiletto.Inject]
        public ThirdService()
        {
        }
    }
}
