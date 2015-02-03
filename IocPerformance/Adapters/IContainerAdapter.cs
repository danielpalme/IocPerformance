﻿using System;
using IocPerformance.Classes;
using IocPerformance.Classes.Generated;

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

        void Prepare();

        object Resolve(Type type);

        void Register(InterfaceAndImplemtation[] services);

        void RegisterMultiTenant(InterfaceAndImplemtation[] services, int numberOfTenants);

        IChildContainerAdapter CreateChildContainerAdapter();
    }
}