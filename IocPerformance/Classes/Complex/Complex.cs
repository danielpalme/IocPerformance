using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Complex
{
    public interface IComplex
    {
    }

    [Export(typeof(IComplex)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class Complex : IComplex
    {
        [ImportingConstructor]
        [Stiletto.Inject]
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
