using System;
using System.Linq;
using System.Threading.Tasks;
using IocPerformance.Classes.Complex;
using IocPerformance.Classes.Dummy;
using IocPerformance.Classes.Multiple;
using IocPerformance.Classes.Properties;
using IocPerformance.Classes.Standard;
using Microsoft.VisualStudio.Composition;

namespace IocPerformance.Adapters
{
    public sealed class VSMefContainerAdapter : ContainerAdapterBase
    {
        private static readonly PartDiscovery partDiscovery = new AttributedPartDiscovery(Resolver.DefaultInstance);

        private ExportProvider container;

        public override string PackageName => "Microsoft.VisualStudio.Composition";

        public override string Url => "https://blogs.msdn.com/b/bclteam/p/composition.aspx";

        public override bool SupportsPropertyInjection => true;

        public override bool SupportsMultiple => true;

        public override bool SupportGeneric => false;

        public override object Resolve(Type type) => this.container.GetExportedValues(type, null).Single();

        public override void Dispose()
        {
            this.container?.Dispose();
            this.container = null;
        }

        public override void Prepare()
        {
            var simpleCatalogTask = RegisterBasicAsync();
            var expandedParts = Task.WhenAll(
                RegisterPropertyInjectionAsync(),
                RegisterMultipleAsync()).GetAwaiter().GetResult();
            var catalog = expandedParts.Aggregate(simpleCatalogTask.GetAwaiter().GetResult(), (cat, discoveredParts) => cat.AddParts(discoveredParts));

            this.container = CompositionConfiguration.Create(catalog)
                .CreateExportProviderFactory()
                .CreateExportProvider();
        }

        public override void PrepareBasic()
        {
            var catalog = RegisterBasicAsync().GetAwaiter().GetResult();
            this.container = CompositionConfiguration.Create(catalog)
                .CreateExportProviderFactory()
                .CreateExportProvider();
        }

        private static async Task<ComposableCatalog> RegisterBasicAsync()
        {
            var parts = await Task.WhenAll(
                RegisterDummiesAsync(),
                RegisterStandardAsync(),
                RegisterComplexObjectAsync());

            return parts.Aggregate(ComposableCatalog.Create(Resolver.DefaultInstance), (catalog, discoveredParts) => catalog.AddParts(discoveredParts));
        }

        private static Task<DiscoveredParts> RegisterMultipleAsync()
        {
            return partDiscovery.CreatePartsAsync(
                typeof(SimpleAdapterOne),
                typeof(SimpleAdapterTwo),
                typeof(SimpleAdapterThree),
                typeof(SimpleAdapterFour),
                typeof(SimpleAdapterFive),
                typeof(ImportMultiple1),
                typeof(ImportMultiple2),
                typeof(ImportMultiple3));
        }

        private static Task<DiscoveredParts> RegisterPropertyInjectionAsync()
        {
            return partDiscovery.CreatePartsAsync(
                typeof(ComplexPropertyObject1),
                typeof(ComplexPropertyObject2),
                typeof(ComplexPropertyObject3),
                typeof(ServiceA),
                typeof(ServiceB),
                typeof(ServiceC),
                typeof(SubObjectA),
                typeof(SubObjectB),
                typeof(SubObjectC));
        }

        private static Task<DiscoveredParts> RegisterComplexObjectAsync()
        {
            return partDiscovery.CreatePartsAsync(
                typeof(FirstService),
                typeof(SecondService),
                typeof(ThirdService),
                typeof(SubObjectOne),
                typeof(SubObjectTwo),
                typeof(SubObjectThree),
                typeof(Complex1),
                typeof(Complex2),
                typeof(Complex3));
        }

        private static Task<DiscoveredParts> RegisterStandardAsync()
        {
            return partDiscovery.CreatePartsAsync(
                typeof(Singleton1),
                typeof(Singleton2),
                typeof(Singleton3),
                typeof(Transient1),
                typeof(Transient2),
                typeof(Transient3),
                typeof(Combined1),
                typeof(Combined2),
                typeof(Combined3));
        }

        private static Task<DiscoveredParts> RegisterDummiesAsync()
        {
            return partDiscovery.CreatePartsAsync(
                typeof(DummyOne),
                typeof(DummyTwo),
                typeof(DummyThree),
                typeof(DummyFour),
                typeof(DummyFive),
                typeof(DummySix),
                typeof(DummySeven),
                typeof(DummyEight),
                typeof(DummyNine),
                typeof(DummyTen));
        }
    }
}
