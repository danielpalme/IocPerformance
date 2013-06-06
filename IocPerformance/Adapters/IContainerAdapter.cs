using System;

namespace IocPerformance.Adapters
{
    public interface IContainerAdapter : IDisposable
    {
        void Prepare();

        object Resolve(Type type);
        object ResolveProxy(Type type);

        string Version { get; }

        bool SupportsInterception { get; }
    }
}