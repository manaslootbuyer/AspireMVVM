using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class AnimatedStackLayout : Xamarin.Forms.StackLayout
    {
        public static BindableProperty ButtonAnimatedProperty =
            BindableProperty.Create("ButtonAnimated", typeof(bool), typeof(Label), false);

        public bool ButtonAnimated
        {
            get { return (bool)GetValue(ButtonAnimatedProperty); }
            set { SetValue(ButtonAnimatedProperty, value); }
        }

    }
}
