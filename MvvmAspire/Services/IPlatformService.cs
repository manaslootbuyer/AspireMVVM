using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmAspire.Services
{
    public interface IPlatformService
    {
        /// <summary>
        /// Loads file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        void CloseSoftKeyoard();
    }
}
