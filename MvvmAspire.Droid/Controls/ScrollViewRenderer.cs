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
using   MvvmAspire.Controls;
using Android;
using Android.Graphics.Drawables;
using System.Threading.Tasks;
using Android.Support.V4.Widget;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.ScrollView), typeof(  MvvmAspire.Controls.ScrollViewRenderer))]
namespace   MvvmAspire.Controls
{

    public class ScrollViewRenderer : Xamarin.Forms.Platform.Android.ScrollViewRenderer
    {
        public ScrollViewRenderer(Context context) : base(context)
        {
        }
        protected ScrollView BaseControl { get { return ((  MvvmAspire.Controls.ScrollView)this.Element); } }
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (!BaseControl.HasScrollbar)
            {
                this.HorizontalScrollBarEnabled = false;
                this.VerticalScrollBarEnabled = false;
            }

        }

      
    }
}