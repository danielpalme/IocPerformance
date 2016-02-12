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
    [IfInjector.ImplementedBy(typeof(SubObjectC))]
    public interface ISubObjectC
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(ISubObjectA))]
    [MEFAttr.ExportAttribute(typeof(ISubObjectC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectC))]
    public class SubObjectC : ISubObjectC
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
