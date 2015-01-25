using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummySeven
    {
    }

    [Export(typeof(IDummySeven)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IDummySeven))]
    public class DummySeven : IDummySeven
    {
    }
}
