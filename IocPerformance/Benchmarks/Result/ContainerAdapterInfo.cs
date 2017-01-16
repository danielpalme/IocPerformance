using System;

namespace IocPerformance.Benchmarks
{
    [Serializable]
    public class ContainerAdapterInfo
    {
        public ContainerAdapterInfo(Adapters.IContainerAdapter container)
        {
            this.Name = container.Name;
            this.Url = container.Url;
            this.Version = container.Version;
        }

        public string Name { get; private set; }

        public string Url { get; private set; }

        public string Version { get; private set; }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Name.Equals(((ContainerAdapterInfo)obj).Name);
        }

        public override int GetHashCode() => this.Name.GetHashCode();
    }
}
