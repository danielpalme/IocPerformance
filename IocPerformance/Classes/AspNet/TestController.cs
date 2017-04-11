using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IocPerformance.Classes.AspNet
{
    public class TestController1 : IDisposable
    {
        private static int counter;
        private static int disposeCount;

        public TestController1(IRepositoryTransient1 transient1, IRepositoryTransient2 repositoryTransient2,
            IRepositoryTransient3 repositoryTransient3)
        {
            if (transient1 == null)
            {
                throw new ArgumentNullException(nameof(transient1));
            }

            if (repositoryTransient2 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient2));
            }

            if (repositoryTransient3 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient3));
            }

            Interlocked.Increment(ref counter);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Interlocked.Increment(ref disposeCount);
        }
        
        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public static int DisposeCount
        {
            get { return disposeCount; }
            set { disposeCount = value; }
        }
    }

    public class TestController2 : IDisposable
    {
        private static int counter;
        private static int disposeCount;

        public TestController2(IRepositoryTransient1 transient1, IRepositoryTransient2 repositoryTransient2,
            IRepositoryTransient3 repositoryTransient3)
        {
            if (transient1 == null)
            {
                throw new ArgumentNullException(nameof(transient1));
            }

            if (repositoryTransient2 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient2));
            }

            if (repositoryTransient3 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient3));
            }

            Interlocked.Increment(ref counter);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Interlocked.Increment(ref disposeCount);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public static int DisposeCount
        {
            get { return disposeCount; }
            set { disposeCount = value; }
        }
    }

    public class TestController3 : IDisposable
    {
        private static int counter;
        private static int disposeCount;

        public TestController3(IRepositoryTransient1 transient1, IRepositoryTransient2 repositoryTransient2,
            IRepositoryTransient3 repositoryTransient3)
        {
            if (transient1 == null)
            {
                throw new ArgumentNullException(nameof(transient1));
            }

            if (repositoryTransient2 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient2));
            }

            if (repositoryTransient3 == null)
            {
                throw new ArgumentNullException(nameof(repositoryTransient3));
            }

            Interlocked.Increment(ref counter);
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Interlocked.Increment(ref disposeCount);
        }

        public static int Instances
        {
            get { return counter; }
            set { counter = value; }
        }

        public static int DisposeCount
        {
            get { return disposeCount; }
            set { disposeCount = value; }
        }
    }
}
