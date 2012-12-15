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

            serviceLocator.RegisterType<ISingleton, Singleton>(RegistrationType.Singleton);

            serviceLocator.RegisterType<ITransient, Transient>(RegistrationType.Transient);

            serviceLocator.RegisterType<ICombined, Combined>(RegistrationType.Transient);

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