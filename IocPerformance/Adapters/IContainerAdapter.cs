using System;

namespace IocPerformance.Adapters
{
    public interface IContainerAdapter : IDisposable
    {
        void Prepare();

        T Resolve<T>() where T : class;

        string Version { get; }
    }
}