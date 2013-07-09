using System;

namespace IocPerformance.Adapters
{
    public interface IContainerAdapter : IDisposable
    {
        string Version { get; }

        string Name { get; }

        string PackageName { get; }

        bool SupportsConditional { get; }

        bool SupportGeneric { get; }

        bool SupportsMultiple { get; }

        bool SupportsInterception { get; }

        void Prepare();

        object Resolve(Type type);

        object ResolveProxy(Type type);
    }
}