using System;

namespace IocPerformance.Adapters
{
    /// <summary>
    /// This interface is used to test child container functionality for dependency injection containers
    /// 
    /// To be included in the test the container has to meet the following three requirements
    /// 
    /// 1) Child container can be created
    /// 2) Child container implements IDisposable
    /// 3) Child container allows new registration to be performed in the child after creation
    /// 
    /// I'm specifically leaving out containers that only support creating new scope lifetimes.
    /// The use case is that you create a new child container, register new exports in the child,
    /// resolve from the child, then destroy child. 
    /// </summary>
    public interface IChildContainerAdapter : IDisposable
    {
        void Prepare();

        T Resolve<T>() where T : class;
    }
}
