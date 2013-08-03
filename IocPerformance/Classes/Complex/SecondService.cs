using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface ISecondService
    {
    }

    [Export(typeof(ISecondService)), PartCreationPolicy(CreationPolicy.Shared)]
    public class SecondService : ISecondService
    {
        [Stiletto.Inject]
        public SecondService()
        {
        }
    }
}
