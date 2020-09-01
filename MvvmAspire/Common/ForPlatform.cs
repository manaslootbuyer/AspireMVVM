using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmAspire.Controls
{
    public class ForPlatform<T>
    {
        public ForPlatform()
        {

        }

        public static implicit operator T(ForPlatform<T> forPlatform)
        {
            T value = forPlatform.Default;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    if (forPlatform.hasSetAndroid)
                        value = forPlatform.Android;
                    break;
                case Device.iOS:
                    if (forPlatform.hasSetiOS)
                        value = forPlatform.iOS;
                    break;
            }
            return value;
        }

        private T _android;
        private bool hasSetAndroid;
        /// <summary>
        /// The type as it is implemented on the Android platform.
        /// </summary>
        public T Android
        {
            get { return _android; }
            set { _android = value; hasSetAndroid = true; }
        }

        private T _iOS;
        private bool hasSetiOS;
        /// <summary>
        /// The type as it is implemented on the iOS platform.
        /// </summary>
        public T iOS
        {
            get { return _iOS; }
            set { _iOS = value; hasSetiOS = true; }
        }

   
        /// <summary>
        /// The default value of the type if not set for the specific platform.
        /// </summary>
        public T Default { get; set; }
    }
}
