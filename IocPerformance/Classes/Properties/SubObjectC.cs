using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using UnityAttr = Microsoft.Practices.Unity;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectC
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(ISubObjectA))]
    [MEFAttr.ExportAttribute(typeof(ISubObjectC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    public class SubObjectC : ISubObjectC
    {
        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        public IServiceC ServiceC { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceC == null)
            {
                throw new Exception("ServiceC was null for SubObjectC for container " + containerName);
            }
        }
    }
}
