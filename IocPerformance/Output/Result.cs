namespace IocPerformance.Output
{
    public class Result
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public long SingletonTime { get; set; }

        public long TransientTime { get; set; }

        public long CombinedTime { get; set; }

        public long ComplexTime { get; set; }

        public long? PropertyInjectionTime { get; set; }

        public long? GenericTime { get; set; }

        public long? ConditionalTime { get; set; }

        public long? MultipleImport { get; set; }

        public long? InterceptionTime { get; set; }
    }
}
