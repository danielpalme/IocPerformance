using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
using UnityAttr = Unity.Attributes;
using MvvmCrossAttr = MvvmCross.IoC;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(ComplexPropertyObject1))]
    public interface IComplexPropertyObject1
    {
        void Verify(string containerName);
    }

    [IfInjector.ImplementedBy(typeof(ComplexPropertyObject2))]
    public interface IComplexPropertyObject2
    {
        void Verify(string containerName);
    }

    [IfInjector.ImplementedBy(typeof(ComplexPropertyObject3))]
    public interface IComplexPropertyObject3
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(IComplexPropertyObject1))]
    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject1))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject1))]
    public class ComplexPropertyObject1 : IComplexPropertyObject1
    {
        private static int counter;

        public ComplexPropertyObject1()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }

    [LinFuAttr.Implements(typeof(IComplexPropertyObject2))]
    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject2))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject2))]
    public class ComplexPropertyObject2 : IComplexPropertyObject2
    {
        private static int counter;

        public ComplexPropertyObject2()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }

    [LinFuAttr.Implements(typeof(IComplexPropertyObject3))]
    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject3))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.Export(typeof(IComplexPropertyObject3))]
    public class ComplexPropertyObject3 : IComplexPropertyObject3
    {
        private static int counter;

        public ComplexPropertyObject3()
        {
            System.Threading.Interlocked.Increment(ref counter);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
        public ISubObjectC SubObjectC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC is null on ComplexPropertyObject for container " + containerName);
            }

            if (this.SubObjectA == null)
            {
                throw new Exception("SubObjectA is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectA.Verify(containerName);

            if (this.SubObjectB == null)
            {
                throw new Exception("SubObjectB is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectB.Verify(containerName);

            if (this.SubObjectC == null)
            {
                throw new Exception("SubObjectC is null on ComplexPropertyObject for container " + containerName);
            }

            this.SubObjectC.Verify(containerName);
        }
    }
}
