using System.ComponentModel.Composition.Hosting;

namespace IocPerformance.Adapters
{
    public sealed class MefContainerAdapter : IContainerAdapter
    {
        private CompositionContainer container;

        public void Prepare()
        {
            var catalog = new AssemblyCatalog(typeof(Program).Assembly);
            this.container = new CompositionContainer(catalog);
        }

        public T Resolve<T>() where T : class
        {
            return this.container.GetExportedValue<T>();
        }

        public void Dispose()
        {
            this.container = null;
        }
    }
}
