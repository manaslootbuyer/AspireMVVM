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
using Android.Graphics;
using   MvvmAspire.Services;
using   MvvmAspire.Util;
using MvvmAspire;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.DatePicker), typeof(  MvvmAspire.Controls.DatePickerRenderer))]
namespace   MvvmAspire.Controls
{
    public class DatePickerRenderer : Xamarin.Forms.Platform.Android.DatePickerRenderer
    {

        public DatePickerRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            var baseElement = e.NewElement as DatePicker;
            base.Control.SetTextColor(baseElement.TextColor.ToAndroid());
            Control.LongClickable = false;

            if (baseElement.BackgroundImage != null && baseElement.BackgroundImage.File != null)
                base.Control.SetBackgroundResource(UIHelper.GetDrawableResource(baseElement.BackgroundImage));

            //var fontName = Resolver.Get<IFontService>().GetFontName(baseElement.FontStyle);
            //if (!string.IsNullOrEmpty(fontName))
            //    SetTypeface(fontName);
            if (baseElement != null)
            {
                SetTextAlignment(baseElement);
                SetBgColor(baseElement);
                SetTextSize(baseElement);
				Control.Text = baseElement.Date.ToString(baseElement.Format);
				Control.TextLocale = Java.Util.Locale.Default;

                baseElement.PropertyChanged += baseElement_PropertyChanged;
            }


        }

        void SetTypeface(string fontName)
        {
            if (!string.IsNullOrEmpty(fontName))
                Control.Typeface = FontCache.GetTypeFace(fontName);
        }


        void baseElement_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (Control == null)
                return;

            var baseElement = sender as   MvvmAspire.Controls.DatePicker;
            switch (e.PropertyName)
            {
				case "Date":
					Control.Text = baseElement.Date.ToString (baseElement.Format);
				break;
                case "TriggerShowDatePicker":
                    Control.CallOnClick();
                    //Control.Raise("Click", EventArgs.Empty);
                    break;

                case "TextColor":
                    //Control.Raise("Click", EventArgs.Empty);

                    if(Control != null)
                    Control.SetTextColor(baseElement.TextColor.ToAndroid());
                    break;
            }
        }

        void SetTextAlignment(  MvvmAspire.Controls.DatePicker element)
        {
            if (Control == null)
                return;

            GravityFlags flags = GravityFlags.NoGravity;

            switch (element.XAlign)
            {
                case   MvvmAspire.TextAlignment.Center:
                    flags = GravityFlags.CenterHorizontal;
                    break;
                case   MvvmAspire.TextAlignment.Left:
                    flags = GravityFlags.Left;
                    break;
                case   MvvmAspire.TextAlignment.Right:
                    flags = GravityFlags.Right;
                    break;
            }

            switch (element.YAlign)
            {
                case   MvvmAspire.TextAlignment.Center:
                    flags |= GravityFlags.CenterVertical;
                    break;
                case   MvvmAspire.TextAlignment.Top:
                    flags |= GravityFlags.Top;
                    break;
                case   MvvmAspire.TextAlignment.Bottom:
                    flags |= GravityFlags.Bottom;
                    break;
            }


			Control.SetPadding(0, 0, 0, 0);
            Control.Gravity = flags;
        }

        protected virtual void SetTextSize(  MvvmAspire.Controls.DatePicker element)
        {
            Control.SetTextSize(Android.Util.ComplexUnitType.Dip, (float)element.FontSize);
        }


        protected virtual void SetBgColor(  MvvmAspire.Controls.DatePicker element)
        {
            if (element.BackgroundColor != null)
                Control.SetBackgroundColor(element.BackgroundColor.ToAndroid());

        }
        
    }
}