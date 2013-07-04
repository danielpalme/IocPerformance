using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummySeven
    {
    }

    [Export(typeof(IDummySeven)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummySeven : IDummySeven
    {
    }
}
