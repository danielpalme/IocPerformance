using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(Complex1))]
    public interface IComplex1
    {
    }

    [Export(typeof(IComplex1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex1))]
    public class Complex1 : IComplex1
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        [IfInjector.Inject]
        public Complex1(
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

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }

    [IfInjector.ImplementedBy(typeof(Complex2))]
    public interface IComplex2
    {
    }

    [Export(typeof(IComplex2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex2))]
    public class Complex2 : IComplex2
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        [IfInjector.Inject]
        public Complex2(
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

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }


    [IfInjector.ImplementedBy(typeof(Complex3))]
    public interface IComplex3
    {
    }

    [Export(typeof(IComplex3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex3))]
    public class Complex3 : IComplex3
    {
        private static int counter;

        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        [IfInjector.Inject]
        public Complex3(
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

            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances { get { return counter; } set { counter = value; } }
    }
}
