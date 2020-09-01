using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class AnimatedLabel : Label
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
