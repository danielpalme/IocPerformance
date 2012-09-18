using Catel.IoC;

namespace IocPerformance.Adapters
{
    public class CatelContainerAdapter : IContainerAdapter
    {
        private IServiceLocator container;

        #region IContainerAdapter Members

        public void Prepare()
        {
            var serviceLocator = new ServiceLocator();

            serviceLocator.RegisterType<ISingleton, Singleton>(false, true);

            serviceLocator.RegisterType<ITransient, Transient>(false, false);

            serviceLocator.RegisterType<ICombined, Combined>(false, false);

            container = serviceLocator;
        }

        public T Resolve<T>() where T : class
        {
            return container.ResolveType<T>();
        }

        public void Dispose()
        {
            // Allow the container and everything it references to be disposed.
            container = null;
        }

        #endregion
    }
}