using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEFAttr = System.ComponentModel.Composition;
using MEF2Attr = System.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using UnityAttr = Microsoft.Practices.Unity;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(SubObjectB))]
    public interface ISubObjectB
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(ISubObjectB))]
    [MEFAttr.ExportAttribute(typeof(ISubObjectB))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectB))]
    public class SubObjectB : ISubObjectB
    {
        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [IfInjector.Inject]
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
