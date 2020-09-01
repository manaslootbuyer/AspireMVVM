  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class RoundedFrame : Grid
    {
        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(RoundedFrame), null);

        //public static BindableProperty BackgroundColorProperty =
        //    BindableProperty.Create <RoundedFrame, Color>(p => p.BackgroundColor, Color.Default);

        public static BindableProperty StartColorProperty =
            BindableProperty.Create("GradientColor", typeof(string), typeof(RoundedFrame), "");

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedFrame), Color.FromHex("#07381a"));

        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(string), typeof(RoundedFrame), "0,0,0,0");

        public static BindableProperty HasBorderProperty =
            BindableProperty.Create("HasBorder", typeof(bool), typeof(RoundedFrame), false);

        public RoundedFrame()
        {
            if (Device.RuntimePlatform == Device.iOS)
                Children.Insert(0, new ContentView());
        }

        public string GradientColor
        {
            get { return (string)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        //public Color BackgroundColor
        //{
        //    get { return (Color)GetValue(BackgroundColorProperty); }
        //    set { SetValue(BackgroundColorProperty, value); }
        //}

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public string CornerRadius
        {
            get { return (string)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
    }
}
