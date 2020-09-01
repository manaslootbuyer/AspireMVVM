using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Switch : Xamarin.Forms.Switch
    {
        public static readonly BindableProperty TextOnProperty =
            BindableProperty.Create("TextOn", typeof(string), typeof(Switch), "");

        public static readonly BindableProperty TextOffProperty =
            BindableProperty.Create("TextOff", typeof(string), typeof(Switch), "");

        public static readonly BindableProperty TrackProperty =
            BindableProperty.Create("SwitchTrack", typeof(FileImageSource), typeof(Switch), null);

        public static readonly BindableProperty TrackDrawableProperty =
            BindableProperty.Create("TrackDrawable", typeof(FileImageSource), typeof(Switch), null);

        public static readonly BindableProperty ThumbDrawableProperty =
            BindableProperty.Create("ThumbDrawable", typeof(FileImageSource), typeof(Switch), null);

        public string TextOn
        {
            get { return (string)GetValue(TextOnProperty); }
            set { SetValue(TextOnProperty, value); }
        }

        public string TextOff
        {
            get { return (string)GetValue(TextOffProperty); }
            set { SetValue(TextOffProperty, value); }
        }

        public FileImageSource SwitchTrack
        {
            get { return (FileImageSource)GetValue(TrackProperty); }
            set { SetValue(TrackProperty, value); }
        }

        public FileImageSource TrackDrawable
        {
            get { return (FileImageSource)GetValue(TrackDrawableProperty); }
            set { SetValue(TrackDrawableProperty, value); }
        }

        public FileImageSource ThumbDrawable
        {
            get { return (FileImageSource)GetValue(ThumbDrawableProperty); }
            set { SetValue(ThumbDrawableProperty, value); }
        }
    }
}
