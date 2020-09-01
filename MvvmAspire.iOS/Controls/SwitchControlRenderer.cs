using System;
using MvvmAspire.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MvvmAspire.Controls.Switch), typeof(SwitchControlRenderer))]

namespace MvvmAspire.Controls
{

    public class SwitchControlRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {

            base.OnElementChanged(e);

            if (Control != null)
            {
               Control.OnTintColor = Color.FromHex("#25A9E0").ToUIColor();
            }
        }

    }
}