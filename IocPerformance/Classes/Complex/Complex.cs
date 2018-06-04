using System;
using System.ComponentModel.Composition;
using MEF2Attr = System.Composition;

namespace IocPerformance.Classes.Complex
{
    [IfInjector.ImplementedBy(typeof(Complex1))]
    public interface IComplex1
    {
    }

    [IfInjector.ImplementedBy(typeof(Complex2))]
    public interface IComplex2
    {
    }

    [IfInjector.ImplementedBy(typeof(Complex2))]
    public interface IComplex3
    {
    }

    [Export(typeof(IComplex1)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex1))]
    public class Complex1 : IComplex1
    {
        protected static int counter;

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
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected Complex1()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(IComplex2)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex2))]
    public class Complex2 : IComplex2
    {
        protected static int counter;

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
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected Complex2()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }

    [Export(typeof(IComplex3)), PartCreationPolicy(CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplex3))]
    public class Complex3 : IComplex3
    {
        protected static int counter;

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
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }

        protected Complex3()
        {
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }
    }


    #region Cauldron 
    /*
        Cauldron is a weaver, means cauldron changes the IL code of the assembly during build.
    */

    [Cauldron.Activator.Component(typeof(IComplex1))]
    public class CauldronComplex1 : Complex1
    {

        [Cauldron.Activator.Inject] private IFirstService firstService;
        [Cauldron.Activator.Inject] private ISecondService secondService;
        [Cauldron.Activator.Inject] private IThirdService thirdService;
        [Cauldron.Activator.Inject] private ISubObjectOne subObjectOne;
        [Cauldron.Activator.Inject] private ISubObjectTwo subObjectTwo;
        [Cauldron.Activator.Inject] private ISubObjectThree subObjectThree;

        public CauldronComplex1()
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    [Cauldron.Activator.Component(typeof(IComplex2))]
    public class CauldronComplex2 : Complex2
    {

        [Cauldron.Activator.Inject] private IFirstService firstService;
        [Cauldron.Activator.Inject] private ISecondService secondService;
        [Cauldron.Activator.Inject] private IThirdService thirdService;
        [Cauldron.Activator.Inject] private ISubObjectOne subObjectOne;
        [Cauldron.Activator.Inject] private ISubObjectTwo subObjectTwo;
        [Cauldron.Activator.Inject] private ISubObjectThree subObjectThree;

        public CauldronComplex2()
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    [Cauldron.Activator.Component(typeof(IComplex3))]
    public class CauldronComplex3 : Complex3
    {

        [Cauldron.Activator.Inject] private IFirstService firstService;
        [Cauldron.Activator.Inject] private ISecondService secondService;
        [Cauldron.Activator.Inject] private IThirdService thirdService;
        [Cauldron.Activator.Inject] private ISubObjectOne subObjectOne;
        [Cauldron.Activator.Inject] private ISubObjectTwo subObjectTwo;
        [Cauldron.Activator.Inject] private ISubObjectThree subObjectThree;

        public CauldronComplex3()
        {
            if (firstService == null)
            {
                throw new ArgumentNullException(nameof(firstService));
            }

            if (secondService == null)
            {
                throw new ArgumentNullException(nameof(secondService));
            }

            if (thirdService == null)
            {
                throw new ArgumentNullException(nameof(thirdService));
            }

            if (subObjectOne == null)
            {
                throw new ArgumentNullException(nameof(subObjectOne));
            }

            if (subObjectTwo == null)
            {
                throw new ArgumentNullException(nameof(subObjectTwo));
            }

            if (subObjectThree == null)
            {
                throw new ArgumentNullException(nameof(subObjectThree));
            }

            System.Threading.Interlocked.Increment(ref counter);
        }
    }

    #endregion
}
