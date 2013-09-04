using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(FirstService))]
    public interface IFirstService
    {
    }

    [Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
    [IfInjector.Singleton]
    public class FirstService : IFirstService
    {
        [Stiletto.Inject]
        public FirstService()
        {
        }
    }
}
