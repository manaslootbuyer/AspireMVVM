using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;
using   MvvmAspire.Controls;
using System.Threading.Tasks;
using Android.Views.InputMethods;
using Android.Graphics.Drawables;
using Android.Text.Method;
using   MvvmAspire.Util;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.Entry), typeof(EntryControlRenderer))]
namespace   MvvmAspire.Controls
{
    public class EntryControlRenderer : EntryRenderer, Android.Widget.TextView.IOnEditorActionListener 
    {
        bool hasCompoundDrawable;

        private Activity _activity;

        const string PlatformRendererFullName = "Xamarin.Forms.Platform.Android.PlatformRenderer";
        static Android.Graphics.Drawables.Drawable originalBackground;

        protected   MvvmAspire.Controls.Entry BaseElement { get { return (  MvvmAspire.Controls.Entry)Element; } }

        IKeyListener DefaultKeyListener = null;
        InputMethodManager inputMethodManager;


        public EntryControlRenderer(Context context) : base(context)
        {
            _activity = this.Context as Activity;
        }

      

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            bool hasSet = false;
            if (e.OldElement == null && this.Element != null)
            {
                //SetNativeControl(new EditTextCustom(Context));
                //SetNativeControl(new EditTextCustom());
                hasSet = true;
            }

            if (inputMethodManager == null)
                inputMethodManager = base.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;

            base.OnElementChanged(e);

            if (!hasSet)
                return;

            var entryControl = (  MvvmAspire.Controls.Entry)Element;


            DefaultKeyListener = Control.KeyListener;

            entryControl.PropertyChanged += (s, ev) =>
            {
                var element = (  MvvmAspire.Controls.Entry)s;

                switch (ev.PropertyName)
                {
                    case "TextPadding":
                    case "ImageLeft":
                    case "ImageRight":
                    case "ImageTop":
                    case "ImageBottom":
                        SetImages(element);
                        break;

                    case "ClearFocusTrigger": HideSoftKeyBoardOnTextChanged(element); break;
                    case "IsFocused": element.ClearFocus = !element.IsFocused; break;
                    case "BackgroundImage": SetBackground(element); break;
                    case "FontFamily": SetTypeface(element); break;
                    case "FontSize": SetTextSize(element); break;
                    case "SuppressKeyboard": SetShowSoftInputOnFocus(element); break;
                    case "Text":
                        if (element.ClearFocus)
                            HideSoftKeyBoardOnTextChanged(element);
                        break;
                    case "ClearFocus":
                        //if (!EntryControl.IsNumeric) break;
                        if (element.ClearFocus)
                        {
                            //inputMethodManager.HideSoftInputFromWindow(base.Control.WindowToken, HideSoftInputFlags.None);
                            //Control.Focusable = false;
                            //Control.ClearFocus();
                            HideSoftKeyBoardOnTextChanged(element);
                        }
                        break;
                    case "NextFocus":
                        inputMethodManager.ShowSoftInput(Control, ShowFlags.Implicit);
                        //inputMethodManager.ToggleSoftInput(ShowFlags.Forced, InputMethodManager.ShowImplicit);
                        break;
                    case "IsEnabled":
                        if (base.Control == null) return;

                        if (!element.IsEnabled)
                            base.Control.KeyListener = null;
                        else
                            base.Control.KeyListener = DefaultKeyListener;
                        break;
					case "IsReadOnly":
						SetIsReadOnly(element);
						break;

                    //case "Padding": SetPadding(element); break;
                }
            };

            //if (EntryControl.IsNumeric)
            //    Control.Touch += Control_Touch;

            SetBackground(entryControl);
            SetImages(entryControl);
            SetTypeface(entryControl);
            SetTextSize(entryControl);
            SetShowSoftInputOnFocus(entryControl);
            SetHintColor(entryControl);
			SetIsReadOnly(entryControl);
            SetTextAlignment();
            //SetPadding(entryControl);
            SetGravity(entryControl);

            if (BaseElement.NextElement != null)
                Control.ImeOptions = ImeAction.Next;
            if (BaseElement.NextElement == null && BaseElement.Command != null)
                Control.ImeOptions = ImeAction.Done;

            if (BaseElement.MaxCharacter.HasValue)
            {
                var filter = new InputFilterLengthFilter(BaseElement.MaxCharacter.Value);
                Control.SetFilters(new IInputFilter[] { filter });
            }

            Control.ViewAttachedToWindow += Control_ViewAttachedToWindow;
            Control.SetPadding(BaseUIHelper.ConvertDPToPixels(BaseElement.Padding.Left),
                               BaseUIHelper.ConvertDPToPixels(BaseElement.Padding.Top),
                               BaseUIHelper.ConvertDPToPixels(BaseElement.Padding.Right),
                               BaseUIHelper.ConvertDPToPixels(BaseElement.Padding.Bottom));

            if (BaseElement.NextElement != null || BaseElement.Command != null)
                Control.SetOnEditorActionListener(this);

            SetTextInputTypes(entryControl);

            if (!entryControl.IsEnabled)
                base.Control.KeyListener = null;

            base.Control.Focusable = !BaseElement.IsReadOnly;

            //Control.Touch += Control_Touch;
            //Control.FocusChange += Control_FocusChange;
            if (BaseElement.IsSingleLine)
            {
                Control.SetMaxLines(1);
                Control.SetSingleLine(true);
                Control.Ellipsize = TextUtils.TruncateAt.End;

            }
			//Control.Gravity = GravityFlags.CenterVertical;
            Control.Background.SetColorFilter(Android.Graphics.Color.Transparent, PorterDuff.Mode.SrcIn);
        }

        private void SetTextAlignment()
        {
            switch (Element.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Center: Control.Gravity = GravityFlags.Center; break;
                case Xamarin.Forms.TextAlignment.End: Control.Gravity = GravityFlags.End | GravityFlags.CenterVertical; break;
                case Xamarin.Forms.TextAlignment.Start: Control.Gravity = GravityFlags.Start | GravityFlags.CenterVertical; break;
            }
        }

        public bool OnEditorAction(TextView v, ImeAction actionId, KeyEvent e)
        {
            if (BaseElement.NextElement == null && (actionId == ImeAction.Done || actionId == ImeAction.Next))
            {
                UIHelper.CloseSoftKeyboard(Control);

                if (BaseElement.Command != null && BaseElement.Command.CanExecute(null))
                {
                    System.Windows.Input.ICommand cmd = BaseElement.Command;
                    cmd.Execute(null);
                }
                return false;
            }

            if (actionId == ImeAction.Done || actionId == ImeAction.Next)
            {
                BaseElement.NextElement.Focus();
                UIHelper.OpenSoftKeyboard(Control);
                return true;
            }

           

            return false;
        }

        void SetHintColor(  MvvmAspire.Controls.Entry element)
        {
            //base.Control.SetHintTextColor(element.HintColor.ToAndroid ());
        }

		void SetIsReadOnly(  MvvmAspire.Controls.Entry element)
		{
			if (element.IsReadOnly)
			{
				base.Control.KeyListener = null;
				element.SuppressKeyboard = true;
                Control.ShowSoftInputOnFocus = false;


			}
			else
				base.Control.KeyListener = DefaultKeyListener;
		}

        void SetGravity(  MvvmAspire.Controls.Entry element)
        {
            if (element.IsRightToLeft){
                base.Control.TextDirection = TextDirection.Rtl;
            }
        }

        void SetTextInputTypes(  MvvmAspire.Controls.Entry element)
        {
            switch (element.TextInputType)
            {
                case TextInputType.Normal: Control.InputType = InputTypes.TextVariationNormal;Control.InputType = InputTypes.TextFlagNoSuggestions; break;
                case TextInputType.EmailAddress: Control.InputType = InputTypes.ClassText | InputTypes.TextVariationEmailAddress; break;
                case TextInputType.Password: Control.InputType = InputTypes.TextVariationPassword; break;
                case TextInputType.Phone: Control.InputType = InputTypes.ClassPhone; break;
                case TextInputType.Number: Control.InputType = InputTypes.ClassNumber; break;
                case TextInputType.PersonName: Control.InputType = InputTypes.TextVariationPersonName | InputTypes.TextFlagCapSentences; break;
                case TextInputType.Decimal: Control.InputType = InputTypes.NumberFlagDecimal; break;
            }
        }

        //void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
        //{
        //    Control.Focusable = true;
        //    Control.RequestFocus();
        //    Control.RequestFocusFromTouch();

        //    Control.SetSelection(Control.Text.Length);

        //    InputMethodManager inputMethodManager = this.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
        //    inputMethodManager.ShowSoftInput(Control, ShowFlags.Forced);
        //    inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        //}

        //override appl
        void HideSoftKeyBoardOnTextChanged(  MvvmAspire.Controls.Entry element)
        {
            if (element.IsFocused && BaseElement.SuppressKeyboard)
            {
                UIHelper.CloseSoftKeyboard(Control);
            }
        }

        void SetShowSoftInputOnFocus(  MvvmAspire.Controls.Entry element)
        {
            Control.ShowSoftInputOnFocus = !BaseElement.SuppressKeyboard;
        }

        protected override void OnFocusChanged(bool gainFocus, FocusSearchDirection direction, Android.Graphics.Rect previouslyFocusedRect)
        {
            base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);

            if (gainFocus && BaseElement.SuppressKeyboard)
            {
                UIHelper.CloseSoftKeyboard(Control);
            }
        }

        //void Control_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        //{
        //    if (e.HasFocus && EntryControl.SuppressKeyboard)
        //    {
        //        UIHelper.CloseSoftKeyboard(Control);
        //    }
        //}

        //void Control_Touch(object sender, Android.Views.View.TouchEventArgs e)
        //{
        //    Control.OnTouchEvent(e.Event);

        //    if (EntryControl.SuppressKeyboard)
        //    {
        //        UIHelper.CloseSoftKeyboard(Control);
        //    }
        //}

        async void Control_ViewAttachedToWindow(object sender, Android.Views.View.ViewAttachedToWindowEventArgs e)
        {
            if (BaseElement.SuppressKeyboard)
            {
                var activity = ((Activity)Context);

                var viewGroup = (ViewGroup)activity.Window.DecorView;
                UnfocusPlatformRenderer(viewGroup);

                await Task.Delay(100);
                UIHelper.CloseSoftKeyboard(Control);
            }
        }

        void PerformKeystroke(Keycode keyCode)
        {
            KeyEvent evt = new KeyEvent(KeyEventActions.Down, keyCode);
            Control.DispatchKeyEvent(evt);
        }

        protected void UnfocusPlatformRenderer(ViewGroup viewGroup)
        {
            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                var vg = viewGroup.GetChildAt(i) as ViewGroup;
                if (vg != null)
                {
                    if (vg.GetType().FullName == PlatformRendererFullName)
                    {
                        vg.Focusable = false;
                        vg.FocusableInTouchMode = false;
                        return;
                    }
                    else
                        UnfocusPlatformRenderer(vg);
                }
            }
        }


        void SetBackground(  MvvmAspire.Controls.Entry element)
        {
            if (Control == null) return;

            bool hasSetOriginal = false;
            if (originalBackground == null)
            {
                originalBackground = Control.Background;
                hasSetOriginal = true;
            }

            if (element.BackgroundImage != null)
            {
                var resourceId = UIHelper.GetDrawableResource(element.BackgroundImage);
                if (resourceId > 0)
                {
                    Control.SetBackgroundResource(resourceId);
                }
                else
                {
                    if (!hasSetOriginal)
                        Control.Background = originalBackground;
                }
            }
            else
            {
                if (!hasSetOriginal)
                    Control.Background = originalBackground;
            }
        }

        void SetImages(  MvvmAspire.Controls.Entry element)
        {
            int leftResourceId = 0, topResourceId = 0, rightResourceId = 0, bottomResourceId = 0;

            if (element.ImageLeft != null && element.ImageLeft.File != null)
                leftResourceId = UIHelper.GetDrawableResource(element.ImageLeft);
            if (element.ImageTop != null && element.ImageTop.File != null)
                topResourceId = UIHelper.GetDrawableResource(element.ImageTop);
            if (element.ImageRight != null && element.ImageRight.File != null)
                rightResourceId = UIHelper.GetDrawableResource(element.ImageRight);
            if (element.ImageBottom != null && element.ImageBottom.File != null)
                bottomResourceId = UIHelper.GetDrawableResource(element.ImageBottom);

            bool hasResource = leftResourceId > 0 || rightResourceId > 0 || topResourceId > 0 || bottomResourceId > 0;
            if (hasCompoundDrawable || hasResource)
            {
                hasCompoundDrawable = true;

                //Android.Graphics.Drawables.Drawable leftDrawable = leftResourceId > 0 ? Resources.GetDrawable(leftResourceId) : null;
                //if (leftDrawable != null)
                //    leftDrawable.SetBounds(0, 0, leftDrawable.IntrinsicWidth, leftDrawable.IntrinsicHeight);
                //Android.Graphics.Drawables.Drawable topDrawable = topResourceId > 0 ? Resources.GetDrawable(topResourceId) : null;
                //if (topDrawable != null)
                //    topDrawable.SetBounds(0, 0, topDrawable.IntrinsicWidth, topDrawable.IntrinsicHeight);
                //Android.Graphics.Drawables.Drawable rightDrawable = rightResourceId > 0 ? Resources.GetDrawable(rightResourceId) : null;
                //if (rightDrawable != null)
                //    rightDrawable.SetBounds(0, 0, rightDrawable.IntrinsicWidth, rightDrawable.IntrinsicHeight);
                //Android.Graphics.Drawables.Drawable bottomDrawable = bottomResourceId > 0 ? Resources.GetDrawable(bottomResourceId) : null;
                //if (bottomDrawable != null)
                //    bottomDrawable.SetBounds(0, 0, bottomDrawable.IntrinsicWidth, bottomDrawable.IntrinsicHeight);

                //Control.SetCompoundDrawablesRelative(leftDrawable, topDrawable, rightDrawable, bottomDrawable);
                //Control.SetCompoundDrawables(leftDrawable, topDrawable, rightDrawable, bottomDrawable);


                var leftDrawable = (leftResourceId > 0) ? Resources.GetDrawable(leftResourceId) : null;
                if (leftDrawable != null)
                {
                    if (element.ImageLeftWidth > 0)
                    {
                        leftDrawable = ResizeImage(leftDrawable, BaseUIHelper.ConvertDPToPixels(element.ImageLeftWidth), BaseUIHelper.ConvertDPToPixels(element.ImageLeftWidth));

                    }
                    else
                    {
                        Resources.GetDrawable(leftResourceId);
                    }
                }

                var topDrawable = (topResourceId > 0) ? Resources.GetDrawable(topResourceId) : null;
                var rightDrawable = (rightResourceId > 0) ? Resources.GetDrawable(rightResourceId) : null;
                var bottomDrawable = (bottomResourceId > 0) ? Resources.GetDrawable(bottomResourceId) : null;

                //Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(leftDrawable, topResourceId, rightResourceId, bottomResourceId);
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(leftDrawable, topDrawable, rightDrawable, bottomDrawable);
                Control.CompoundDrawablePadding = 20;

                if (!hasResource)
                    hasCompoundDrawable = false;
            }

            if (element.ImageCenter != null)
            {
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(base.Resources.GetDrawable(UIHelper.GetDrawableResource(element.ImageCenter)), null, null, null);
                Control.Gravity = GravityFlags.Center;
            }
        }

        private Drawable ResizeImage(Drawable image, int width, int height)
        {
            Bitmap b = ((BitmapDrawable)image).Bitmap;
            Bitmap bitmapResized = Bitmap.CreateScaledBitmap(b, width, height, false);
            return new BitmapDrawable(bitmapResized);
        }

        void SetTypeface(  MvvmAspire.Controls.Entry element)
        {
            if (!string.IsNullOrEmpty(element.FontFamily))
                 Control.Typeface = FontCache.GetTypeFace(element.FontFamily);
        }

        void SetTextSize(  MvvmAspire.Controls.Entry element)
        {
            Control.TextSize = (float)element.FontSize;
        }

        //void SetPadding(  MvvmAspire.Controls.Entry element)
        //{
        //    Control.SetPadding(BaseUIHelper.ConvertDPToPixels(element.Padding.Left),
        //        BaseUIHelper.ConvertDPToPixels(element.Padding.Top),
        //        BaseUIHelper.ConvertDPToPixels(element.Padding.Right),
        //        BaseUIHelper.ConvertDPToPixels(element.Padding.Bottom)); 
        //}

    }
}