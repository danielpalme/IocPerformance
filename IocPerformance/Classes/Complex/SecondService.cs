using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(SecondService))]
    public interface ISecondService
    {
    }

    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    [IfInjector.Singleton]
    public class SecondService : ISecondService
    {
        [Stiletto.Inject]
        public SecondService()
        {
        }
    }
}
