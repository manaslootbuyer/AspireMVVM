using MvvmAspire.Controls;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Drawing;

namespace MvvmAspire.Controls
{
    public class EntryControlRenderer : EntryRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged (e);
            if (e.OldElement != null || this.Element == null)
                return;

            Control.ShouldReturn = new UITextFieldCondition (OnShouldReturn);
            Control.ShouldChangeCharacters = OnShouldChangeCharacters;
            DisableDefaultKeyboard ();

            var element = Element as Entry;
            if (element != null) {
                SetAccesibilityLabel(element);
                SetBorderRadius (element);
                SetTextColor (element);
                SetFont (element);
                SetReturnKeyType (element);
                SetTextInputTypes (element);
                SetIsReadOnly(element);
                SetIsRightToLeft(element);

                element.PropertyChanged += (s, ev) =>
                {
                    if (Control == null || Element == null)
                        return;

                    switch (ev.PropertyName)
                    {
                        case "AccesibilitySetFocus": SetAccesibilityFocus(element); break;
                        default: break;
                    }
                };

                if(!element.IsEnabled)
                {
                    SetDisabledTextColor(element);
                }

             

                Element.Focused += (sender, args) => 
                {
                    UIAccessibility.PostNotification(UIAccessibilityPostNotification.ScreenChanged, Control.InputAccessoryView);
                };
            }
        }



        void SetBorderRadius (Entry element)
        {
            
            if (element.BorderRadius != 1) {
                Control.BorderStyle = UITextBorderStyle.RoundedRect;
                Control.Layer.BorderWidth = element.BorderRadius;
            }
            if (element.BackgroundColor == Xamarin.Forms.Color.Transparent) {
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }

        void SetTextInputTypes (Entry element)
        {
            switch (element.TextInputType) {
                case TextInputType.Normal:
                    Control.KeyboardType = UIKeyboardType.Default;
                    break;
                case TextInputType.EmailAddress:
                    Control.KeyboardType = UIKeyboardType.EmailAddress;
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
                    break;
                case TextInputType.Password:
                    Control.KeyboardType = UIKeyboardType.Default;
                    break;
                case TextInputType.Phone:
                    Control.KeyboardType = UIKeyboardType.PhonePad;
                    break;
                case TextInputType.Number:
                    Control.KeyboardType = UIKeyboardType.NumberPad;
                    break;
                case TextInputType.PersonName:
                    Control.KeyboardType = UIKeyboardType.Default;
                    break;
                case TextInputType.None:
                    Control.AutocapitalizationType = UITextAutocapitalizationType.None;
                    break;
                case TextInputType.Decimal:
                    Control.KeyboardType = UIKeyboardType.DecimalPad;
                    break;

            }

            Control.AutocorrectionType = UITextAutocorrectionType.No;
            Control.SpellCheckingType = UITextSpellCheckingType.No;
        }

        private bool OnShouldReturn (UITextField view)
        {
            var shouldReturn = true;

            var element = Element as Entry;
            if (view.ReturnKeyType == UIReturnKeyType.Next) {
                if (element.NextElement != null) {
                    element.NextElement.Focus ();
                    shouldReturn = false;
                } 
            } else if (view.ReturnKeyType == UIReturnKeyType.Done || view.ReturnKeyType == UIReturnKeyType.Send
                || view.ReturnKeyType == UIReturnKeyType.Go) {
                Control.ResignFirstResponder ();
                if (element.Command != null && element.Command.CanExecute (null))
                    element.Command.Execute (null);
            }

            Element.Raise ("Completed", EventArgs.Empty);
            return shouldReturn;
        }

        private bool OnShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
        {
            var baseElement = Element as MvvmAspire.Controls.Entry;
            if (baseElement != null && baseElement.MaxCharacter.HasValue && baseElement.MaxCharacter.Value > 0)
            {
                var newLength = (int)(textField.Text.Length + replacementString.Length - range.Length);
                return newLength <= baseElement.MaxCharacter.Value;
            }

            return true;
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            var element = Element as MvvmAspire.Controls.Entry;

            if (e.PropertyName == Entry.FontFamilyProperty.PropertyName ||
                e.PropertyName == Entry.FontSizeProperty.PropertyName) {
                SetFont (element);
            } else if (e.PropertyName == Entry.TextColorProperty.PropertyName) {
                SetTextColor (element);
            } else if (e.PropertyName == Entry.ReturnKeyTypeProperty.PropertyName) {
                SetReturnKeyType (element);
            } else if (e.PropertyName == Entry.IsReadOnlyProperty.PropertyName) {
                SetIsReadOnly(element);
            }
            else if (e.PropertyName == Entry.TextProperty.PropertyName)
            {
                SetAccesibilityLabel(element);
            }
            else if (e.PropertyName == Entry.IsEnabledProperty.PropertyName && !Control.Enabled)
            {
                SetDisabledTextColor(element);
            }
            //else if (e.PropertyName == Entry.AccesibilitySetFocusProperty.PropertyName && !Control.Enabled)
            //{
            //    SetAccesibilityFocus(element);
            //}
        }

        void DisableDefaultKeyboard ()
        {
            if (((MvvmAspire.Controls.Entry)Element).SuppressKeyboard) {
                Control.InputView = new UIView ();
                ReloadInputViews ();
            }
        }

        void SetFont (MvvmAspire.Controls.Entry element)
        {
            //if (Control.Font == null
            //             || Control.Font.FamilyName != element.FontFamily
            //             || Control.Font.PointSize != (nfloat)element.FontSize) {
            //  Control.Font = UIFont.FromName (element.FontFamily, (nfloat)element.FontSize);
            //}

            if (Control.Font == null
                        || Control.Font.PointSize != (nfloat)element.FontSize)
            {
                Control.Font = UIFont.FromName(Control.Font.FamilyName, (nfloat)element.FontSize);
            }
        }

        void SetTextColor (MvvmAspire.Controls.Entry element)
        {
            Control.TextColor = element.TextColor.ToUIColor (UIColor.DarkTextColor);
        }

        void SetReturnKeyType (MvvmAspire.Controls.Entry element)
        {
            if (element.ReturnKeyType == ReturnKeyType.Automatic) {
                if (element.NextElement != null)
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                else if (element.Command != null)
                    Control.ReturnKeyType = UIReturnKeyType.Done;
            } else if (element.ReturnKeyType == ReturnKeyType.Default)
                Control.ReturnKeyType = UIReturnKeyType.Default;
            else if (element.ReturnKeyType == ReturnKeyType.Go)
                Control.ReturnKeyType = UIReturnKeyType.Go;
            else if (element.ReturnKeyType == ReturnKeyType.Search)
                Control.ReturnKeyType = UIReturnKeyType.Search;
            else if (element.ReturnKeyType == ReturnKeyType.Next)
                Control.ReturnKeyType = UIReturnKeyType.Next;
            else if (element.ReturnKeyType == ReturnKeyType.Done)
                Control.ReturnKeyType = UIReturnKeyType.Done;
            else if (element.ReturnKeyType == ReturnKeyType.Search)
                Control.ReturnKeyType = UIReturnKeyType.Search;
            else if (element.ReturnKeyType == ReturnKeyType.Send)
                Control.ReturnKeyType = UIReturnKeyType.Send;
        }

        protected void AddDoneButton(Entry element)
        {
            UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));

            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
                this.Control.ResignFirstResponder();
                UIAccessibility.PostNotification(UIAccessibilityPostNotification.ScreenChanged, Control);
            });

            toolbar.Items = new UIBarButtonItem[] {
                new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
                doneButton
            };
            Control.InputAccessoryView = toolbar;
        }

        void SetIsReadOnly(MvvmAspire.Controls.Entry element)
        {
            if (UIAccessibility.IsVoiceOverRunning)
            {
                Control.UserInteractionEnabled = !element.IsReadOnly;
                if (element.IsReadOnly)
                    Control.AccessibilityTraits = UIAccessibilityTrait.StaticText;
                else
                    Control.AccessibilityTraits = UIAccessibilityTrait.None;
            }
            else
                Control.Enabled = !element.IsReadOnly;
        }

        void SetAccesibilityLabel(MvvmAspire.Controls.Entry element)
        {
            if (UIAccessibility.IsVoiceOverRunning)
            {
                if (Control.Placeholder != null && Control.Text != string.Empty && !element.AccesibilityIgnoreNameWhenNotEmpty)
                    Control.AccessibilityLabel =  string.Concat("required, ",Control.Placeholder) ;
                else
                    Control.AccessibilityLabel = "required, ";
            }

        }

        void SetAccesibilityFocus(MvvmAspire.Controls.Entry element)
        {
            if (UIAccessibility.IsVoiceOverRunning && element.AccesibilitySetFocus)
            {
                UIAccessibility.PostNotification(UIAccessibilityPostNotification.ScreenChanged, Control);
                element.AccesibilitySetFocus = false;
            }

        }


        void SetIsRightToLeft(MvvmAspire.Controls.Entry element)
        {

            if(element.IsRightToLeft)
                Control.TextAlignment = UITextAlignment.Right;
        }

        private void PerformKeystroke (char c)
        {
            if (!Control.IsFirstResponder)
                Control.BecomeFirstResponder ();

            if (c != '\b') { // if number key has been pressed
                if (Control.Text == string.Empty)
                    Control.Text += c;
                else {
                    var textRangeStartPosition = Control.SelectedTextRange.Start;
                    this.Element.Text = Control.Text = GetTextBeforeCursor () + c + GetTextAfterCursor ();

                    var newCursorPosition = Control.GetPosition (textRangeStartPosition, 1);
                    Control.SelectedTextRange = Control.GetTextRange (newCursorPosition, newCursorPosition);
                }
            } else { // if delete key has been pressed
                if (Control.Text != string.Empty) {
                    if (!Control.SelectedTextRange.Start.IsEqual (Control.SelectedTextRange.End)) { // Has selected text
                        var textRangeStartPosition = Control.SelectedTextRange.Start;
                        this.Element.Text = Control.Text = GetTextBeforeCursor () + GetTextAfterCursor ();
                        Control.SelectedTextRange = Control.GetTextRange (textRangeStartPosition, textRangeStartPosition);
                    } else {
                        if (Control.BeginningOfDocument != Control.SelectedTextRange.Start) {
                            var textRangeStartPosition = Control.SelectedTextRange.Start;
                            var cursorPositionStart = (int)Control.GetOffsetFromPosition (Control.BeginningOfDocument, textRangeStartPosition);
                            this.Element.Text = Control.Text = GetTextBeforeCursor ().Substring (0, cursorPositionStart - 1) + GetTextAfterCursor ();

                            var newCursorPosition = Control.GetPosition (textRangeStartPosition, -1);
                            Control.SelectedTextRange = Control.GetTextRange (newCursorPosition, newCursorPosition);
                        }
                    }
                }
            }
        }

        private string GetTextBeforeCursor ()
        {
            var cursorPositionStart = (int)Control.GetOffsetFromPosition (Control.BeginningOfDocument, Control.SelectedTextRange.Start);

            var textBeforeCursor = string.Empty;
            if (cursorPositionStart > 0)
                textBeforeCursor = Control.Text.Substring (0, cursorPositionStart);

            return textBeforeCursor;
        }

        private string GetTextAfterCursor ()
        {
            var cursorPositionEnd = (int)Control.GetOffsetFromPosition (Control.BeginningOfDocument, Control.SelectedTextRange.End);

            var textAfterCursor = string.Empty;
            if (Control.Text.Length > cursorPositionEnd)
                textAfterCursor = Control.Text.Substring (cursorPositionEnd, Control.Text.Length - cursorPositionEnd);

            return textAfterCursor;
        }

        private void SetDisabledTextColor(MvvmAspire.Controls.Entry element)
        {
            Control.TextColor = element.DisabledTextColor.ToUIColor();
            Control.AttributedPlaceholder = new NSAttributedString(element.Placeholder, new UIStringAttributes {ForegroundColor = element.DisabledTextColor.ToUIColor()});
        }
    
    }
}