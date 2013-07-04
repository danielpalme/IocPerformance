using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummySix
    {
    }

    [Export(typeof(IDummySix)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummySix : IDummySix
    {
    }
}
