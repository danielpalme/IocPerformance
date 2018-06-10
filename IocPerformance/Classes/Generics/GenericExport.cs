using IocPerformance.Classes.Generics;
using System.ComponentModel.Composition;

[module: Cauldron.Activator.GenericComponent(typeof(GenericExport<int>), typeof(IGenericInterface<int>))]
[module: Cauldron.Activator.GenericComponent(typeof(GenericExport<float>), typeof(IGenericInterface<float>))]
[module: Cauldron.Activator.GenericComponent(typeof(GenericExport<object>), typeof(IGenericInterface<object>))]

namespace IocPerformance.Classes.Generics
{
    [Export(typeof(IGenericInterface<>)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(IGenericInterface<>))]
    public class GenericExport<T> : IGenericInterface<T>
    {
        public T Value { get; set; }
    }
}
