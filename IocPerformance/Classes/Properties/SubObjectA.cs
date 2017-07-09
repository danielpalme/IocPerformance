using System;
using LinFuAttr = LinFu.IoC.Configuration;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using MugenAttr = MugenInjection.Attributes;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
using StructureAttr = StructureMap.Attributes;
using UnityAttr = Microsoft.Practices.Unity;

namespace IocPerformance.Classes.Properties
{
    [IfInjector.ImplementedBy(typeof(SubObjectA))]
    public interface ISubObjectA
    {
        void Verify(string containerName);
    }

    [LinFuAttr.Implements(typeof(ISubObjectA))]
    [MEFAttr.ExportAttribute(typeof(ISubObjectA))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectA))]
    public class SubObjectA : ISubObjectA
    {
        [MEFAttr.Import]
        [MEF2Attr.Import]
        [LinFuAttr.Inject]
        [MugenAttr.Inject]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [StructureAttr.SetterProperty]
        [Stiletto.Inject]
        [IfInjector.Inject]
        [StashBoxAttr.Dependency]
        [MicroResolver.Inject]
        public IServiceA ServiceA { get; set; }

        public void Verify(string containerName)
        {
            if (this.ServiceA == null)
            {
                throw new Exception("ServiceA was null for SubObjectC for container " + containerName);
            }
        }
    }
}
