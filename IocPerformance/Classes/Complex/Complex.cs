using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(Complex))]
    public interface IComplex
    {
    }

    [Export(typeof(IComplex)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex))]
    public class Complex : IComplex
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        [IfInjector.Inject]
        public Complex(
            IFirstService firstService,
            ISecondService secondService,
            IThirdService thirdService,
            ISubObjectOne subObjectOne,
            ISubObjectTwo subObjectTwo,
            ISubObjectThree subObjectThree)
        {
            if (firstService == null)
            {
                throw new ArgumentNullException("firstService");
            }

            if (secondService == null)
            {
                throw new ArgumentNullException("secondService");
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException("thirdService");
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException("subObjectOne");
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException("subObjectTwo");
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException("subObjectThree");
            }

            Instances++;
        }

        public static int Instances { get; set; }
    }
}
