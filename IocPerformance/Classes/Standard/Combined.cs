using System;
using System.ComponentModel.Composition;

namespace IocPerformance.Classes.Standard
{
    [IfInjector.ImplementedBy(typeof(Combined))]
    public interface ICombined
    {
        void DoSomething();
    }

    [Export(typeof(ICombined)), PartCreationPolicy(CreationPolicy.NonShared)]
    [System.Composition.Export(typeof(ICombined))]
    public class Combined : ICombined
    {
        [ImportingConstructor]
        [System.Composition.ImportingConstructor]
        [Stiletto.Inject]
        public Combined(ISingleton first, ITransient second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            Instances++;
        }

        public static int Instances { get; set; }

        public void DoSomething()
        {
            Console.WriteLine("Combined");
        }
    }
}
