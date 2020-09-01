using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmAspire.Services
{
    public class DispatcherService : IDispatcherService
    {
        public void BeginInvokeOnMainThread(Action action)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(action);
        }
    }
}
