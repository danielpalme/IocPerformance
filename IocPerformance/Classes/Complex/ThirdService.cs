using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(ThirdService))]
    public interface IThirdService
    {
    }

    [Export(typeof(IThirdService)), PartCreationPolicy(CreationPolicy.Shared)]
    [IfInjector.Singleton]
    public class ThirdService : IThirdService
    {
        [Stiletto.Inject]
        public ThirdService()
        {
        }
    }
}
