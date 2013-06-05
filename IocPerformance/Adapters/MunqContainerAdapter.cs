﻿using System;
using System.Linq;
using System.Xml.Linq;
using Munq;
using Munq.LifetimeManagers;

namespace IocPerformance.Adapters
{
    public sealed class MunqContainerAdapter : IContainerAdapter
    {
        private IocContainer container;

        public string Version
        {
            get
            {
                return XDocument
                    .Load("packages.config")
                    .Root
                    .Elements()
                    .First(e => e.Attribute("id").Value == "Munq.IocContainer")
                    .Attribute("version").Value;
            }
        }

        public bool SupportsInterception { get { return false; } }

        public void Prepare()
        {
            // I made an optimization here, since Munq allows to do constructor injection. Not only is this
            // the preferable way of doing things, it is faster.
            this.container = new IocContainer();
            this.container.Register<ISingleton, Singleton>().WithLifetimeManager(new ContainerLifetime());
            this.container.Register<ITransient, Transient>().WithLifetimeManager(new AlwaysNewLifetime());
            this.container.Register<ICombined, Combined>().WithLifetimeManager(new AlwaysNewLifetime());
        }

		public object Resolve(Type type)
		{
			return this.container.Resolve(type);
		}

		public object ResolveProxy(Type type)
		{
			return this.container.Resolve(type);
		}

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}