using System;

namespace IocPerformance.Adapters
{
    public interface IContainerAdapter : IDisposable
    {
        string Version { get; }

        string Name { get; }

        string PackageName { get; }

        string Url { get; }

        bool SupportsConditional { get; }

        bool SupportGeneric { get; }

        bool SupportsMultiple { get; }

        bool SupportsInterception { get; }

        bool SupportsPropertyInjection { get; }

        bool SupportsChildContainer { get; }

        bool SupportAspNetCore { get; }

        /// <summary>
        /// Prepares basic registration. All containers support basic features to be named containers.
        /// Allows fair comparison of feature poor vs rich containers, so additional registrations do not degrade richer containers.
        /// </summary>
        void PrepareBasic();

        void Prepare();

        object Resolve(Type type);

        IChildContainerAdapter CreateChildContainerAdapter();
    }
}