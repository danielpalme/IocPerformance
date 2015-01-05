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
   
        
        /// <summary>
        /// Returns true container supports common features which are must for any container to allow fair comparison of feature poor vs rich containers.
        /// </summary>
        bool SupportsBasic{get;}
        
        /// <summary>
        /// Prepares basic registration if <see cref="SupportsBasic"/> is true.
        /// </summary>
        void PrepareBasic();
        

        void Prepare();

        object Resolve(Type type);

        IChildContainerAdapter CreateChildContainerAdapter();
    }
}