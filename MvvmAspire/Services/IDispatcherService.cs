using System;
namespace MvvmAspire.Services
{
    public interface IDispatcherService
    {
        /// <summary>
        /// Invokes an action on the main thread.
        /// </summary>
        /// <param name="action"></param>
        void BeginInvokeOnMainThread(Action action);
    }
}
