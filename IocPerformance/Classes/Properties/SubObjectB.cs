using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
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
        [StashBoxAttr.Dependency]
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
