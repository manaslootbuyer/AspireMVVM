using MvvmAspire.Controls;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Reflection;

namespace MvvmAspire.Controls
{
    public class EditorControlRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            //DisableDefaultKeyboard();

            var element = Element as MvvmAspire.Controls.Editor;
            if (element != null)
            {
                SetAccesibilityLabel(element);
                SetTextAlignment(element);
                SetTextColor(element);
                SetFont(element);
                SetMaxCharacter(element);
                AddPlaceHolder(element);
                SetReadOnly(element);
                //((IKeyPressHandler)element).SetPerformKeyPress(key =>
                //{
                //    var code = key.ToChar();
                //    if (code.HasValue)
                //        PerformKeystroke(code.Value);
                //});

				if (element.Text != null && element.Text.Length > 0)
				{
					Control.Tag = 1;
				}
            }
             
            Control.ScrollEnabled = false;
			Control.TextContainerInset = new UIEdgeInsets(5, 0, 5, 5);
            Control.ReturnKeyType = UIReturnKeyType.Default;
            Control.AutocorrectionType = (element.EnableAutoCorrect) ? UITextAutocorrectionType.Default : UITextAutocorrectionType.No;
            SetInputAccessory(element);
        }

        void SetInputAccessory(MvvmAspire.Controls.Editor element)
        {
            UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));
            toolbar.BackgroundColor = element.InputAccessoryBackgroundColor.ToUIColor();

            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
            {
                this.Control.ResignFirstResponder();
            });

            toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};
            this.Control.InputAccessoryView = toolbar;
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = Element as MvvmAspire.Controls.Editor;

            if (e.PropertyName == Editor.FontFamilyProperty.PropertyName
                || e.PropertyName == Editor.FontSizeProperty.PropertyName)
            {
                SetFont(element);
            }
            else if (e.PropertyName == Editor.TextColorProperty.PropertyName)
            {
                SetTextColor(element);
            }
            else if (e.PropertyName == Editor.TextAlignmentProperty.PropertyName)
            {
                SetTextAlignment(element);
            }
            else if (e.PropertyName == Editor.MaxCharacterProperty.PropertyName)
            {
                SetMaxCharacter(element);
            }
            else if (e.PropertyName == Editor.PlaceholderProperty.PropertyName)
            {
                AddPlaceHolder(element);
            }
            else if (e.PropertyName == Editor.IsReadOnlyProperty.PropertyName)
            {
                SetReadOnly(element);
            }
            else if (e.PropertyName == Editor.TextProperty.PropertyName)
            {
                if (element.Text == element.Placeholder)
                    Control.TextColor = element.PlaceHolderColor.ToUIColor();
                else
                    Control.TextColor = element.TextColor.ToUIColor();

                //SetTextColor(element);
				if (element.Text.Length > 0)
				{
					Control.Tag = 1;
				}
            }
        }

        void SetMaxCharacter(MvvmAspire.Controls.Editor element)
        {
            Control.ShouldChangeText += ShouldLimit;
        }

        void AddPlaceHolder(MvvmAspire.Controls.Editor element)
        {
            Control.ShouldBeginEditing = ((textView) =>
                    {
                        if (Control.Tag == 0)
                        {
                            Control.Text = string.Empty;
                            Control.TextColor = element.TextColor.ToUIColor();
                            Control.Tag = 1;
                        }
                        return true;
                    });
            Control.ShouldEndEditing = ((textView) =>
                    {
                        if (Control.Text.Length == 0)
                        {
                            Control.Text = element.Placeholder;
                            Control.TextColor = element.PlaceHolderColor.ToUIColor();
                            Control.Tag = 0;
                        }
                        return true;
                    });
			if (Control.Text.Length == 0)
			{
				Control.Text = element.Placeholder;
                Control.TextColor = element.PlaceHolderColor.ToUIColor();
				Control.Tag = 0;
			}
        }

        void SetReadOnly(MvvmAspire.Controls.Editor element)
        {
            Control.Editable = !element.IsReadOnly;
        }

        public bool ShouldLimit(UITextView view, NSRange range, string text)
        {
            var element = Element as MvvmAspire.Controls.Editor;

            if (!element.MaxCharacter.HasValue)
                return true;

            var textView = Control;
            var limit = element.MaxCharacter;

            var newLength = textView.Text.Length + text.Length - range.Length;
            return newLength <= element.MaxCharacter;
        }

        void DisableDefaultKeyboard()
        {
            if (((MvvmAspire.Controls.Editor)Element).SuppressKeyboard)
            {
                Control.InputView = new UIView();
                ReloadInputViews();
            }
        }

        void SetFont(MvvmAspire.Controls.Editor element)
        {
            //if (Control.Font == null
            //    || Control.Font.FamilyName != element.FontFamily
            //    || Control.Font.PointSize != (nfloat)element.FontSize)
            //{
            //    Control.Font = UIFont.FromName(element.FontFamily, (nfloat)element.FontSize);
            //}

            if (Control.Font == null
                  || Control.Font.PointSize != (nfloat)element.FontSize)
            {
                Control.Font = UIFont.FromName(Control.Font.FamilyName, (nfloat)element.FontSize);
            }
        }

        void SetTextColor(MvvmAspire.Controls.Editor element)
        {
            Control.TextColor = element.TextColor.ToUIColor(UIColor.White);
        }

        void SetTextAlignment(MvvmAspire.Controls.Editor element)
        {
            if (element.TextAlignment == TextAlignment.Left)
                Control.TextAlignment = UITextAlignment.Left;
            else if (element.TextAlignment == TextAlignment.Center)
                Control.TextAlignment = UITextAlignment.Center;
            else if (element.TextAlignment == TextAlignment.Right)
                Control.TextAlignment = UITextAlignment.Right;
            else if (element.TextAlignment == TextAlignment.Justified)
                Control.TextAlignment = UITextAlignment.Justified;
        }

        void SetAccesibilityLabel(MvvmAspire.Controls.Editor element)
        {
            if (UIAccessibility.IsVoiceOverRunning)
            {
                if( element.Placeholder != null && element.Placeholder.ToLower().Contains("optional"))
                {
                    if(Control.Text != string.Empty)
                    {
                        Control.AccessibilityLabel = element.Placeholder;
                    }
                    else
                    {
                        Control.AccessibilityLabel = "";
                    }

                }
                else{
                    if (element.Placeholder != null && Control.Text != string.Empty)
                        Control.AccessibilityLabel = string.Concat("required, ", element.Placeholder);
                    else
                        Control.AccessibilityLabel = "required, ";
                }

            }
        }

        private void PerformKeystroke(char c)
        {
            if (!Control.IsFirstResponder)
                Control.BecomeFirstResponder();

            if (c != '\b') // if number key has been pressed
            {
                if (Control.Text == string.Empty)
                    Control.Text += c;
                else
                {
                    var textRangeStartPosition = Control.SelectedTextRange.Start;
                    this.Element.Text = Control.Text = GetTextBeforeCursor() + c + GetTextAfterCursor();

                    var newCursorPosition = Control.GetPosition(textRangeStartPosition, 1);
                    Control.SelectedTextRange = Control.GetTextRange(newCursorPosition, newCursorPosition);
                }
            }
            else // if delete key has been pressed
            {
                if (Control.Text != string.Empty)
                {
                    if (!Control.SelectedTextRange.Start.IsEqual(Control.SelectedTextRange.End)) // Has selected text
                    {
                        var textRangeStartPosition = Control.SelectedTextRange.Start;
                        this.Element.Text = Control.Text = GetTextBeforeCursor() + GetTextAfterCursor();
                        Control.SelectedTextRange = Control.GetTextRange(textRangeStartPosition, textRangeStartPosition);
                    }
                    else
                    {
                        if (Control.BeginningOfDocument != Control.SelectedTextRange.Start)
                        {
                            var textRangeStartPosition = Control.SelectedTextRange.Start;
                            var cursorPositionStart = (int)Control.GetOffsetFromPosition(Control.BeginningOfDocument, textRangeStartPosition);
                            this.Element.Text = Control.Text = GetTextBeforeCursor().Substring(0, cursorPositionStart - 1) + GetTextAfterCursor();

                            var newCursorPosition = Control.GetPosition(textRangeStartPosition, -1);
                            Control.SelectedTextRange = Control.GetTextRange(newCursorPosition, newCursorPosition);
                        }
                    }
                }
            }
        }

        private string GetTextBeforeCursor()
        {
            var cursorPositionStart = (int)Control.GetOffsetFromPosition(Control.BeginningOfDocument, Control.SelectedTextRange.Start);

            var textBeforeCursor = string.Empty;
            if (cursorPositionStart > 0)
                textBeforeCursor = Control.Text.Substring(0, cursorPositionStart);

            return textBeforeCursor;
        }

        private string GetTextAfterCursor()
        {
            var cursorPositionEnd = (int)Control.GetOffsetFromPosition(Control.BeginningOfDocument, Control.SelectedTextRange.End);

            var textAfterCursor = string.Empty;
            if (Control.Text.Length > cursorPositionEnd)
                textAfterCursor = Control.Text.Substring(cursorPositionEnd, Control.Text.Length - cursorPositionEnd);

            return textAfterCursor;
        }


    }
}