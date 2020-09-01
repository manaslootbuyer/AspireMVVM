using System;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class RoundedButton : Button
    {
        /// <summary>
        /// FOR WINDOWS BUTTON ONLY
        /// </summary>
        public static BindableProperty ReAppearingProperty =
            BindableProperty.Create("ReAppearing", typeof(bool), typeof(RoundedButton), true, BindingMode.TwoWay);

        public static BindableProperty HasShadowProperty =
            BindableProperty.Create("HasShadow", typeof(bool), typeof(RoundedButton), false, BindingMode.TwoWay);

        public static BindableProperty OrientationProperty =
            BindableProperty.Create("Orientation", typeof(GradientOrientation), typeof(RoundedButton), GradientOrientation.TopBottom);

        public static BindableProperty StartColorProperty =
            BindableProperty.Create("GradientColor", typeof(string), typeof(RoundedButton), "");

        public static BindableProperty HoverColorProperty =
            BindableProperty.Create("HoverColor", typeof(string), typeof(RoundedButton), "");

        public static BindableProperty DisableColorProperty =
            BindableProperty.Create("DisableColor", typeof(string), typeof(RoundedButton), "");

        public static BindableProperty PressedColorProperty =
            BindableProperty.Create("PressedColor", typeof(string), typeof(RoundedButton), "");

        public static BindableProperty GradientTypeProperty =
            BindableProperty.Create("GradientStyle", typeof(GradientType), typeof(RoundedButton), GradientType.Linear);

        public static BindableProperty BackgroundGradientStyleProperty =
            BindableProperty.Create("BackgroundGradientStyle", typeof(BackgroundGradientType), typeof(RoundedButton), BackgroundGradientType.GradientBackground);


        public bool ReAppearing
        {
            get { return (bool)GetValue(ReAppearingProperty); }
            set { SetValue(ReAppearingProperty, value); }
        }

        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }


        public GradientOrientation Orientation
        {
            get { return (GradientOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public string GradientColor
        {
            get { return (string)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }
        public string HoverColor
        {
            get { return (string)GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }

        public string DisableColor
        {
            get { return (string)GetValue(DisableColorProperty); }
            set { SetValue(DisableColorProperty, value); }
        }

        public string PressedColor
        {
            get { return (string)GetValue(PressedColorProperty); }
            set { SetValue(PressedColorProperty, value); }
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

        public RoundedButton()
        {
            //SetFontFamily();
            //AutomationProperties.SetIsInAccessibleTree(this, true);
            //this.PropertyChanged += (s, e) =>
            //{
            //    if (e.PropertyName == "FontStyle")
            //        SetFontFamily();


            //};



        }

    }
}
