using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IFirstService
    {
    }

    [Export(typeof(IFirstService)), PartCreationPolicy(CreationPolicy.Shared)]
    public class FirstService : IFirstService
    {
    }
}
