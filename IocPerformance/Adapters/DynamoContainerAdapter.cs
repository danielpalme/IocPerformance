using System;
using System.Linq;
using System.Xml.Linq;
using Dynamo.Ioc;

namespace IocPerformance.Adapters
{
    public sealed class DynamoContainerAdapter : ContainerAdapterBase
    {
        private IocContainer container;

        protected override string PackageName
        {
            get { return "Dynamo.Ioc"; }
        }

        public override void Prepare()
        {
            this.container = new IocContainer(defaultCompileMode: CompileMode.Dynamic);

            this.container.Register<ISingleton, Singleton>().WithContainerLifetime();
            this.container.Register<ITransient, Transient>();
            this.container.Register<ICombined, Combined>();
            this.container.Compile();
        }

        public override object Resolve(Type type)
        {
            return this.container.Resolve(type);
        }

        public override void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}