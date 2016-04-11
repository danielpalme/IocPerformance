using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(SubObjectTwo))]
    public interface ISubObjectTwo
    {
    }

    [Export(typeof(ISubObjectTwo)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectTwo))]
    public class SubObjectTwo : ISubObjectTwo
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public SubObjectTwo(ISecondService secondService)
        {
            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }
        }
    }
}
