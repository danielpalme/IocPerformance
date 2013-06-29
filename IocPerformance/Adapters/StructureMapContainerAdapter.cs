using System;
using IocPerformance.Classes.Standard;
using IocPerformance.Interception;
using StructureMap;

namespace IocPerformance.Adapters
{
    public sealed class StructureMapContainerAdapter : ContainerAdapterBase
    {
        private Container container;

		  public override string PackageName
        {
            get { return "structuremap"; }
        }
        public override bool SupportsInterception { get { return true; } }

        public override void Prepare()
        {
            var pg = new Castle.DynamicProxy.ProxyGenerator();

            this.container = new Container(r =>
            {
                r.For<ISingleton>().Singleton().Use<Singleton>();
                r.For<ITransient>().Transient().Use<Transient>();
                r.For<ICombined>().Transient().Use<Combined>();
                r.For<ICalculator>().Transient().Use<Calculator>()
                    .EnrichWith(c => pg.CreateInterfaceProxyWithTarget<ICalculator>(c, new StructureMapInterceptionLogger()));
            });
        }

        public override object Resolve(Type type)
        {
            return this.container.GetInstance(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}