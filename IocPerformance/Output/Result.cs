
namespace IocPerformance.Output
{
    public class Result
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public long SingletonTime { get; set; }

        public long TransientTime { get; set; }

        public long CombinedTime { get; set; }

        public int SingletonInstances { get; set; }

        public int TransientInstances { get; set; }

        public int CombinedInstances { get; set; }
    }
}
