using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Dummy
{
    public interface IDummyTwo
    {
    }

    [Export(typeof(IDummyTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DummyTwo : IDummyTwo
    {
    }
}
