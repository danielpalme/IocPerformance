using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using UnityAttr = Microsoft.Practices.Unity;

namespace IocPerformance.Classes.Properties
{
    public interface IComplexPropertyObject
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(IComplexPropertyObject))]
    [MEFAttr.ExportAttribute(typeof(IComplexPropertyObject))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    public class ComplexPropertyObject : IComplexPropertyObject
    {
        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public IServiceA ServiceA { get; set; }

        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public IServiceB ServiceB { get; set; }

        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public IServiceC ServiceC { get; set; }

        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public ISubObjectA SubObjectA { get; set; }

        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public ISubObjectB SubObjectB { get; set; }

        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
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
