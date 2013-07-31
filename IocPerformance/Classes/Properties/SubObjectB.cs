using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using UnityAttr = Microsoft.Practices.Unity;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectB
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(ISubObjectB))]
    [MEFAttr.ExportAttribute(typeof(ISubObjectB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    public class SubObjectB : ISubObjectB
    {
        [MEFAttr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        public IServiceB ServiceB { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceB == null)
            {
                throw new Exception("ServiceB was null for SubObjectC for container " + containerName);
            }
        }
    }
}
