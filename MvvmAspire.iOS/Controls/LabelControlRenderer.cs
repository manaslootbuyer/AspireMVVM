using System;
using System.Drawing;
using System.ComponentModel;
#if __UNIFIED__
using UIKit;
using CoreText;
#else
using MonoTouch.UIKit;
using MonoTouch.CoreText;
#endif
#if __UNIFIED__
using RectangleF = CoreGraphics.CGRect;
using SizeF = CoreGraphics.CGSize;
using PointF = CoreGraphics.CGPoint;
using Xamarin.Forms;

#else
using nfloat=System.Single;
using nint=System.Int32;
using nuint=System.UInt32;
#endif
using Xamarin.Forms.Platform.iOS;

namespace MvvmAspire.Controls
{
    using Size = Xamarin.Forms.Size;
    using TextAlignment = Xamarin.Forms.TextAlignment;
    using CoreGraphics;
    using System.Diagnostics;
    using System.Collections.Generic;
    using Foundation;

    public class LabelControlRenderer : ViewRenderer<Label, UILabel>
    {
        SizeRequest _perfectSize;

        bool _perfectSizeValid;

        protected MvvmAspire.Controls.Label BaseElement { get { return (MvvmAspire.Controls.Label)Element; } }

        public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
        {
            if (!_perfectSizeValid)
            {
                _perfectSize = base.GetDesiredSize(double.PositiveInfinity, double.PositiveInfinity);
                _perfectSize.Minimum = new Size(Math.Min(10, _perfectSize.Request.Width), _perfectSize.Request.Height);
                _perfectSizeValid = true;
            }

            if (widthConstraint >= _perfectSize.Request.Width && heightConstraint >= _perfectSize.Request.Height)
                return _perfectSize;

            var result = base.GetDesiredSize(widthConstraint, heightConstraint);
            result.Minimum = new Size(Math.Min(10, result.Request.Width), result.Request.Height);
            if ((Element.LineBreakMode & (LineBreakMode.TailTruncation | LineBreakMode.HeadTruncation | LineBreakMode.MiddleTruncation)) != 0)
            {
                if (result.Request.Width > widthConstraint)
                    result.Request = new Size(Math.Max(result.Minimum.Width, widthConstraint), result.Request.Height);
            }

            return result;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            if (Control == null)
                return;

            SizeF fitSize;
            nfloat labelHeight;
            switch (Element.VerticalTextAlignment)
            {

                case TextAlignment.Start:
                    fitSize = Control.SizeThatFits(Element.Bounds.Size.ToSizeF());
                    labelHeight = (nfloat)Math.Min(Bounds.Height, fitSize.Height);
                    Control.Frame = new RectangleF(0, 0, (nfloat)Element.Width, labelHeight);
                    break;
                case TextAlignment.Center:
                    Control.Frame = new RectangleF(0, 0, (nfloat)Element.Width, (nfloat)Element.Height);
                    break;
                case TextAlignment.End:
                    nfloat yOffset = 0;
                    fitSize = Control.SizeThatFits(Element.Bounds.Size.ToSizeF());
                    labelHeight = (nfloat)Math.Min(Bounds.Height, fitSize.Height);
                    yOffset = (nfloat)(Element.Height - labelHeight);
                    Control.Frame = new RectangleF(0, yOffset, (nfloat)Element.Width, labelHeight);
                    break;
            }
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Label> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var label = new UILabelWithPadding(RectangleF.Empty)
                    {
                        Insets = new UIEdgeInsets((nfloat)e.NewElement.Padding.Top, (nfloat)e.NewElement.Padding.Left,
                            (nfloat)e.NewElement.Padding.Bottom, (nfloat)e.NewElement.Padding.Right),
                        BackgroundColor = UIColor.Clear
                    };

                    SetNativeControl(label);
                }

				SetMaxWidth();
                UpdateText();
                UpdateLineBreakMode();
                UpdateAlignment();

                SetMaxLines();
                SetInputType();
                SetCommand();
                SetTextStyle();
                SetAccessibilityTraits();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.HorizontalTextAlignmentProperty.PropertyName)
                UpdateAlignment();
            else if (e.PropertyName == Label.VerticalTextAlignmentProperty.PropertyName)
                LayoutSubviews();
            else if (e.PropertyName == Label.TextColorProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == Label.FontProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == Label.TextProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == Label.FormattedTextProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == Label.LineBreakModeProperty.PropertyName)
                UpdateLineBreakMode();
            else if (e.PropertyName == Label.CommandProperty.PropertyName)
                SetCommand();
            else if (e.PropertyName == Label.InputTypeProperty.PropertyName)
                SetInputType();
            else if (e.PropertyName == Label.MaxLinesProperty.PropertyName)
                SetMaxLines();
            else if (e.PropertyName == Label.TextStyleProperty.PropertyName)
                SetTextStyle();
            else if (e.PropertyName == Label.MaxWidthProperty.PropertyName)
                SetMaxWidth();
            else if (e.PropertyName == Label.AccessibilityTraitsProperty.PropertyName)
                SetAccessibilityTraits();
            else if (e.PropertyName == Label.AccesibilitySetFocusProperty.PropertyName && BaseElement != null)
                SetAccesibilityFocus(BaseElement);
        }

        protected override void SetBackgroundColor(Xamarin.Forms.Color color)
        {
            if (color == Xamarin.Forms.Color.Default)
                BackgroundColor = UIColor.Clear;
            else
                BackgroundColor = color.ToUIColor();
        }

        void UpdateAlignment()
        {
            Control.TextAlignment = Element.HorizontalTextAlignment.ToNativeTextAlignment();
        }

        void UpdateLineBreakMode()
        {
            _perfectSizeValid = false;

            switch (Element.LineBreakMode)
            {
                case LineBreakMode.NoWrap:
                    Control.LineBreakMode = UILineBreakMode.Clip;
                    Control.Lines = 1;
                    break;
                case LineBreakMode.WordWrap:
                    Control.LineBreakMode = UILineBreakMode.WordWrap;
                    Control.Lines = 0;
                    break;
                case LineBreakMode.CharacterWrap:
                    Control.LineBreakMode = UILineBreakMode.CharacterWrap;
                    Control.Lines = 0;
                    break;
                case LineBreakMode.HeadTruncation:
                    Control.LineBreakMode = UILineBreakMode.HeadTruncation;
                    Control.Lines = 1;
                    break;
                case LineBreakMode.MiddleTruncation:
                    Control.LineBreakMode = UILineBreakMode.MiddleTruncation;
                    Control.Lines = 1;
                    break;
                case LineBreakMode.TailTruncation:
                    Control.LineBreakMode = UILineBreakMode.TailTruncation;
                    Control.Lines = 1;
                    break;
            }
        }

        void UpdateText()
        {
            _perfectSizeValid = false;

            //var values = Element.GetValues(Label.FormattedTextProperty, Label.TextProperty, Label.TextColorProperty);
            var formatted = (FormattedString)Element.GetValue(Label.FormattedTextProperty); //(FormattedString)values[0];
            var color = (Xamarin.Forms.Color)Element.GetValue(Label.TextColorProperty);

            if (formatted != null)
            {
                //Control.AttributedText = formatted.ToAttributed(Element, color);
            }
            else
            {
                var value = Element.GetValue(Label.TextProperty);

                Control.Text = (string)value;
				// default value of color documented to be black in iOS docs
				if(Element.Font.ToUIFont()!=null)
				Control.Font = Element.Font.ToUIFont();
              
				Control.TextColor = ((Xamarin.Forms.Color)color).ToUIColor(UIColor.Black);
            }
            Control.AccessibilityLabel = Element.Text;
            SetTextStyle();

            LayoutSubviews();
        }

		void SetMaxWidth()
		{
			var baseElement = Element as MvvmAspire.Controls.Label;
			if (baseElement == null)
				return;

			if (baseElement.MaxWidth.HasValue)
				Element.WidthRequest = baseElement.MaxWidth.Value;
			else
				Element.WidthRequest = -1;
		}

        private void SetAccessibilityTraits()
        {
            var baseElement = Element as MvvmAspire.Controls.Label;

            if (baseElement != null)
            {
                AutomationProperties.SetIsInAccessibleTree(baseElement, true);

                if (baseElement.AccessibilityTraits != string.Empty)
                {
                    var accessiblityTrait = baseElement.AccessibilityTraits;
                    switch (accessiblityTrait)
                    {
                        case "button":
                            base.Control.AccessibilityTraits = UIAccessibilityTrait.Button;
                            break;
                        case "header":
                            base.Control.AccessibilityTraits = UIAccessibilityTrait.Header;
                            break;
                        case "tabs":
                            AutomationProperties.SetName(baseElement, string.Concat(baseElement.Text, ". Tab."));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        void SetAccesibilityFocus(MvvmAspire.Controls.Label element)
        {
            if (UIAccessibility.IsVoiceOverRunning && element.AccesibilitySetFocus)
            {
                UIAccessibility.PostNotification(UIAccessibilityPostNotification.ScreenChanged, Control);
                element.AccesibilitySetFocus = false;
            }

        }

        UITapGestureRecognizer commandGestureRecognizer;
        void SetCommand()
        {
            if (BaseElement == null || Control == null)
                return;

            if (BaseElement.Command != null)
            {
                if (commandGestureRecognizer == null)
                    commandGestureRecognizer = new UITapGestureRecognizer(() =>
                    {
						if (BaseElement.Command != null && BaseElement.Command.CanExecute(BaseElement.CommandParameter))
                            BaseElement.Command.Execute(BaseElement.CommandParameter);
                    });
                Control.AddGestureRecognizer(commandGestureRecognizer);
                Control.UserInteractionEnabled = true;
            }
            else
            {
                if (commandGestureRecognizer != null)
                    Control.RemoveGestureRecognizer(commandGestureRecognizer);
                Control.UserInteractionEnabled = false;
            }
        }

        void SetTextStyle()
        {
            if (BaseElement == null || Control == null)
                return;

            if (BaseElement.TextStyle == TextStyling.Underline)
            {
                if (BaseElement.Text == null)
                    return;

                var attrString = new NSAttributedString(BaseElement.Text, underlineStyle: NSUnderlineStyle.Single);
                Control.AttributedText = attrString;
            }
        }

        void SetInputType()
        {
            if (BaseElement == null || Control == null)
                return;

            if (string.IsNullOrEmpty(BaseElement.Text))
                return;

            var linkAttribute = new UIStringAttributes
            {
                ForegroundColor = UIColor.Blue,
                UnderlineStyle = NSUnderlineStyle.Single,
                UnderlineColor = UIColor.Blue
            };

            if (BaseElement.InputType == TextInputType.Phone)
            {
                Control.UserInteractionEnabled = true;
                UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(() =>
                {
                    var phoneNumber = BaseElement.Text;
                    NSUrl url = new NSUrl(string.Format(@"telprompt://{0}", phoneNumber));

                    if (UIApplication.SharedApplication.CanOpenUrl(url))
                        UIApplication.SharedApplication.OpenUrl(url);
                }
                                                    );
                tapGesture.NumberOfTapsRequired = 1;

                var formattedString = new NSMutableAttributedString(BaseElement.Text);
                formattedString.SetAttributes(linkAttribute.Dictionary, new NSRange(0, BaseElement.Text.Length));

                Control.AttributedText = formattedString;
                Control.AddGestureRecognizer(tapGesture);
            }
            else if (BaseElement.InputType == TextInputType.EmailAddress)
            {
                Control.UserInteractionEnabled = true;
                UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(() =>
                    {
                        var emailAddress = BaseElement.Text;
                        NSUrl url = new NSUrl(string.Format(@"mailto://{0}", emailAddress));

                        UIApplication.SharedApplication.OpenUrl(url);
                    }
                );
                tapGesture.NumberOfTapsRequired = 1;

                var formattedString = new NSMutableAttributedString(BaseElement.Text);
                formattedString.SetAttributes(linkAttribute.Dictionary, new NSRange(0, BaseElement.Text.Length));

                Control.AttributedText = formattedString;
                Control.AddGestureRecognizer(tapGesture);
            }
            else if (BaseElement.InputType == TextInputType.Website)
            {
                Control.UserInteractionEnabled = true;
                UITapGestureRecognizer tapGesture = new UITapGestureRecognizer(() =>
                {
                    UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(BaseElement.Text));
                });
                tapGesture.NumberOfTapsRequired = 1;
                Control.AddGestureRecognizer(tapGesture);
            }
        }

        void SetMaxLines()
        {
            if (BaseElement == null || Control == null)
                return;

            if (BaseElement.MaxLines > 0)
                Control.Lines = BaseElement.MaxLines;
        }
    }

    public class UILabelWithPadding : UILabel
    {
        public UILabelWithPadding()
        {

        }
        public UILabelWithPadding(CGRect frame)
            : base(frame)
        {

        }

        public UIEdgeInsets Insets { get; set; }

        public override void DrawText(CGRect rect)
        {
            base.DrawText(Insets.InsetRect(rect));
        }
    }

    internal static class AlignmentExtensions
    {
        internal static UITextAlignment ToNativeTextAlignment(this TextAlignment alignment)
        {
            switch (alignment)
            {
                case TextAlignment.Center:
                    return UITextAlignment.Center;
                case TextAlignment.End:
                    return UITextAlignment.Right;
                default:
                    return UITextAlignment.Left;
            }
        }
    }
}