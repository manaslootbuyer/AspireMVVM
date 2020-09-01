using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Picker : Xamarin.Forms.Picker
    {
        public static readonly BindableProperty DefaultTextColorProperty =
            BindableProperty.Create("DefaultTextColor", typeof(Color), typeof(Picker), Color.Default);

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(Picker), Color.Default);

        public Color DefaultTextColor
        {
            get { return (Color)GetValue(DefaultTextColorProperty); }
            set { SetValue(DefaultTextColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
