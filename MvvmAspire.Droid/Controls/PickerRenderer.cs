using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.Picker), typeof(  MvvmAspire.Controls.PickerRenderer))]
namespace   MvvmAspire.Controls
{
    public class PickerRenderer : Xamarin.Forms.Platform.Android.PickerRenderer
    {
        protected   MvvmAspire.Controls.Picker Base { get { return (  MvvmAspire.Controls.Picker)Element; } }
        protected Android.Widget.EditText MyControl { get { return (this.Control); } }


        public PickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);

            MyControl.SetTextColor(Base.TextColor.ToAndroid());
            MyControl.SetBackgroundDrawable(this.Resources.GetDrawable("button_white_outline"));
            MyControl.SetCompoundDrawablesWithIntrinsicBounds(null, null, this.Resources.GetDrawable("dropdown"), null);
        }
    }
}