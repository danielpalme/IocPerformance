using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(SubObjectThree))]
    public interface ISubObjectThree
    {
    }

    [Export(typeof(ISubObjectThree)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class SubObjectThree : ISubObjectThree
    {
        [ImportingConstructor]
        [Stiletto.Inject]
        public SubObjectThree(IThirdService thirdService)
        {
            if (thirdService == null)
            {
                throw new ArgumentNullException("thirdService");
            }
        }
    }
}
