using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IThirdService
    {
    }

    [Export(typeof(IThirdService)), PartCreationPolicy(CreationPolicy.Shared)]
    public class ThirdService : IThirdService
    {
        [Stiletto.Inject]
        public ThirdService()
        {
        }
    }
}
