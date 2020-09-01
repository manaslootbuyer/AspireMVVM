using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MvvmAspire.Controls
{
	public class PickerControlRenderer : Xamarin.Forms.Platform.iOS.PickerRenderer
	{
        UIColor textColor = UIColor.White;
		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.Picker> e)
		{
			base.OnElementChanged(e);
			if (e.OldElement != null || this.Element == null)
				return;

			var element = Element as MvvmAspire.Controls.Picker;
			if (element != null)
			{
				SetTextColor(element);
                SetBorderColor(element);

                //var test = true;

                if(textColor.ToColor() !=  UIColor.White.ToColor())
                {
                    setPlaceHolderColor(element);
                }

                if (UIAccessibility.IsVoiceOverRunning)
                {
                    AutomationProperties.SetIsInAccessibleTree(element, true);
                }
                //if( !test )
                    //setPlaceHolderColor(element);
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var element = Element as MvvmAspire.Controls.Picker;
			if (element != null)
			{
				if (e.PropertyName == "TextColor")
					SetTextColor(element);
				else if (e.PropertyName == "BorderColor")
					SetBorderColor(element);
                else if (e.PropertyName == "SelectedIndex" && textColor != UIColor.White)
                    setPlaceHolderColor(element);
			}
		}

        void setPlaceHolderColor(MvvmAspire.Controls.Picker element)
        {
            
            if (element.SelectedIndex <= 0)
            {
                //connecrt to cyc colors grayforms
                Control.TextColor = Color.FromHex("9B9B9B").ToUIColor() ;
            }
            else{
                Control.TextColor = textColor;
            }
        }

		void SetTextColor(MvvmAspire.Controls.Picker element)
		{
			Control.TextColor = element.TextColor.ToUIColor();
            textColor = element.TextColor.ToUIColor();


		}

		void SetBorderColor(MvvmAspire.Controls.Picker element)
		{
			if (element.BorderColor == Color.Transparent)
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
			else
				Control.Layer.BorderColor = element.BorderColor.ToCGColor();
		}
	}
}
