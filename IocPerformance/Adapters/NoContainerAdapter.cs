using System;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : IContainerAdapter
    {
        private static readonly Type IInterface1Type = typeof(IInterface1);
        private static readonly Type IInterface2Type = typeof(IInterface2);
        private static readonly Type CombinedType = typeof(ICombined);

        private static readonly IInterface1 singleton = new Implementation1();

        public void Prepare()
        {
        }

        public T Resolve<T>() where T : class
        {
            Type serviceType = typeof(T);

            if (serviceType == IInterface1Type)
            {
                return (T)singleton;
            }
            else if (serviceType == IInterface2Type)
            {
                IInterface2 transient = new Implementation2();
                return (T)transient;
            }
            else if (serviceType == CombinedType)
            {
                ICombined combined = new Combined(singleton, new Implementation2());
                return (T)combined;
            }

            throw new InvalidOperationException(typeof(T).FullName);
        }

        public void Dispose()
        {
        }
    }
}