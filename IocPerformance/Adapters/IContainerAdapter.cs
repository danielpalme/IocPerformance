using System;

namespace IocPerformance.Adapters
{
    public interface IContainerAdapter : IDisposable
    {
        void Prepare();

        T Resolve<T>() where T : class;

        T ResolveProxy<T>() where T : class;

        string Version { get; }

        bool SupportsInterception { get; }
    }
}