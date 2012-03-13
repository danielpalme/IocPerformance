using System.Collections;
using Spring.Context;
using Spring.Objects.Factory;

namespace IocPerformance.Adapters
{
    public sealed class SpringContainerAdapter : IContainerAdapter
    {
        private IApplicationContext container;

        public void Prepare()
        {
            this.container = Spring.Context.Support.ContextRegistry.GetContext();
        }

        public T Resolve<T>() where T : class
        {
            IEnumerator enumerator = this.container.GetObjectsOfType(typeof(T)).Values.GetEnumerator();

            if (!enumerator.MoveNext())
            {
                throw new ObjectCreationException(string.Format("no services of type '{0}' defined", typeof(T).FullName));
            }

            return (T)enumerator.Current;
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            this.container = null;
        }
    }
}