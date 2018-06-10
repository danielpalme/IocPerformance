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

        protected SubObjectTwo()
        {
        }
    }

    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
    */

    [Cauldron.Activator.Component(typeof(ISubObjectTwo))]
    public class CauldronSubObjectTwo : SubObjectTwo
    {
        [Cauldron.Activator.Inject]
        private ISecondService secondService;

        public CauldronSubObjectTwo() : base()
        {
            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }
        }
    }


    #endregion
}
