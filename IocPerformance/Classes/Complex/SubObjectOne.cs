using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(SubObjectOne))]
    public interface ISubObjectOne
    {
    }

    [Export(typeof(ISubObjectOne)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(ISubObjectOne))]
    public class SubObjectOne : ISubObjectOne
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public SubObjectOne(IFirstService firstService)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }
        }

        protected SubObjectOne()
        {
        }
    }


    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
    */

    [Cauldron.Activator.Component(typeof(ISubObjectOne))]
    public class CauldronSubObjectOne : SubObjectOne
    {
        [Cauldron.Activator.Inject]
        private IFirstService firstService;

        public CauldronSubObjectOne() : base()
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }
        }
    }


    #endregion
}
