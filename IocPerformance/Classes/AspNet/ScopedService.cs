using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IocPerformance.Classes.AspNet
{
    public interface IScopedService
    {
        void DoSomething();
    }

    public class ScopedService : IScopedService
    {
        private static int counter;

        public ScopedService()
        {
            Interlocked.Increment(ref counter);
        }
        
        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public void DoSomething()
        {
            
        }
    }
}
