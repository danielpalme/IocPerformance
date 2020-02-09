using System;
using MEF2Attr = System.Composition;
using MEFAttr = System.ComponentModel.Composition;
using NinjectAttr = Ninject;
using StashBoxAttr = Stashbox.Attributes;
using UnityAttr = Unity;
using MvvmCrossAttr = MvvmCross.IoC;

namespace IocPerformance.Classes.Properties
{
    public interface ISubObjectC
    {
        void Verify(string containerName);
    }

    [MEFAttr.ExportAttribute(typeof(ISubObjectC))]
    [MEFAttr.PartCreationPolicy(MEFAttr.CreationPolicy.NonShared)]
    [MEF2Attr.ExportAttribute(typeof(ISubObjectC))]
    public class SubObjectC : ISubObjectC
    {
        [MEFAttr.Import]
        [MEF2Attr.Import]
        [NinjectAttr.Inject]
        [UnityAttr.Dependency]
        [Stiletto.Inject]
        [StashBoxAttr.Dependency]
        [MvvmCrossAttr.MvxInject]
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
