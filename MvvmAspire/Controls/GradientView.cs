using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class GradientView : Xamarin.Forms.Image
    {
        public static BindableProperty OrientationProperty =
            BindableProperty.Create("Orientation", typeof(GradientOrientation), typeof(GradientView), GradientOrientation.TopBottom);

        public static BindableProperty StartColorProperty =
            BindableProperty.Create("StartColor", typeof(Color), typeof(GradientView), Color.Transparent);

        public static BindableProperty EndColorViewProperty =
            BindableProperty.Create("EndColor", typeof(Color), typeof(GradientView), Color.Transparent);

        public static BindableProperty GradientTypeProperty =
            BindableProperty.Create("GradientStyle", typeof(GradientType), typeof(GradientView), GradientType.Linear);

        public static BindableProperty BackgroundGradientStyleProperty =
            BindableProperty.Create("BackgroundGradientStyle", typeof(BackgroundGradientType), typeof(GradientView), BackgroundGradientType.GradientBackground);

        public static readonly BindableProperty ImagePlaceholderProperty =
            BindableProperty.Create("ImagePlaceholder", typeof(ImageSource), typeof(GradientView), null);

        public GradientOrientation Orientation
        {
            get { return (GradientOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorViewProperty); }
            set { SetValue(EndColorViewProperty, value); }
        }

        public GradientType GradientStyle
        {
            get { return (GradientType)GetValue(GradientTypeProperty); }
            set { SetValue(GradientTypeProperty, value); }
        }

        public BackgroundGradientType BackgroundGradientStyle
        {
            get { return (BackgroundGradientType)GetValue(BackgroundGradientStyleProperty); }
            set { SetValue(BackgroundGradientStyleProperty, value); }
        }

        public ImageSource ImagePlaceholder
        {
            get { return (ImageSource)base.GetValue(ImagePlaceholderProperty); }
            set { base.SetValue(ImagePlaceholderProperty, value); }
        }
    }
}
