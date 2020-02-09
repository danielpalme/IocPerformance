using System;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using MvvmCrossAttr = MvvmCross.IoC;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
using StructureAttr = StructureMap.Attributes;
using UnityAttr = Unity;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectA
    {
        void Verify(string containerName);
    }

    [MEFAttr.ExportAttribute(typeof(ISubObjectA))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectA))]
    public class SubObjectA : ISubObjectA
    {
        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [StructureAttr.SetterProperty]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
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
