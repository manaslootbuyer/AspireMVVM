using Android.Text;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using   MvvmAspire.Controls;
using Android.App;
using System.Threading.Tasks;
using   MvvmAspire.Util;
using Android.Text.Method;
using Android.Content;
using System;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.Editor), typeof(EditorControlRenderer))]
namespace   MvvmAspire.Controls
{
    public class EditorControlRenderer : EditorRenderer //ViewRenderer<  MvvmAspire.Controls.Entry, EditTextCustom>, 
    {
        const string PlatformRendererFullName = "Xamarin.Forms.Platform.Android.PlatformRenderer";
        static Android.Graphics.Drawables.Drawable originalBackground;

		IKeyListener DefaultKeyListener = null;

        protected Editor BaseElement { get { return (Editor)Element; } }


        public EditorControlRenderer(Context context) : base(context)
        {

        }



        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            bool hasSet = false;

      
            if (e.OldElement == null && this.Element != null)
            {
                //SetNativeControl(new EditTextCustom(Context));
                //SetNativeControl(new EditTextCustom());
                hasSet = true;
            }

            base.OnElementChanged(e);

            if (!hasSet)
                return;

            if (Control != null) 
            {
				DefaultKeyListener = Control.KeyListener;
                // do whatever you want to the textField here!
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

                if (BaseElement.BackgroundImage != null && BaseElement.BackgroundImage.File != null)
                {
                    var resourceId = UIHelper.GetDrawableResource(BaseElement.BackgroundImage);
                    Control.SetBackgroundResource(resourceId);
                }
                
                Control.Hint = BaseElement.Placeholder;
                Control.SetHintTextColor(BaseElement.PlaceHolderColor.ToAndroid());

                if (BaseElement.MaxCharacter.HasValue)
                    Control.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(BaseElement.MaxCharacter.Value) });

            }
            var editorControl = (Editor)Element;

           

            editorControl.PropertyChanged += async (s, ev) =>
            {
                if (Element == null || Control == null)
                    return;

                var element = (Editor)s;

                switch (ev.PropertyName)
                {
                    case "BackgroundImage": SetBackground(element); break;
                    case "FontFamily": SetTypeface(element); break;
                    case "FontSize": SetTextSize(element); break;
                    case "TextAlignment": SetTextAlignment(element); break;
                    case "SuppressKeyboard": SetShowSoftInputOnFocus(element); break;
                    case "Text": HideSoftKeyBoardOnTextChanged(element); break;
                    case "IsReadOnly": SetIsReadOnly(element); break;
                    case "IsFocused":
                        var x = Control.IsInTouchMode;
                        if (!element.IsFocused)
                        {

                            try
                            {
                                //Control.EditorAction += (object sender, Android.Widget.TextView.EditorActionEventArgs evt) => evt.Handled = true;
                                await Task.Delay(10);
                                //Control.Focusable = false;
                                //Control.Clickable = false;
                                Control.ClearFocus();
                                ////Control.ClearFocus();
                                //await Task.Delay(10);

                                Control.Focusable = false;
                                Control.FocusableInTouchMode = false;
                                Control.Focusable = true;
                                Control.FocusableInTouchMode = true;
                            }
                            catch (Exception)
                            {

                            }
                        }
                        break;

                }
            };

            //Control.TextChanged += (s, ev) => Element.Raise("TextChanged", ev);
            //Control.Completed += (s, ev) => Element.Raise("Completed", ev);
            Control.SetPadding(5, 5, 5, 5);
            //Control.Focusable = false;
            //Control.FocusableInTouchMode = true;
            SetBackground(editorControl);
            SetTypeface(editorControl);
            SetTextSize(editorControl);
            SetTextAlignment(editorControl);
            SetShowSoftInputOnFocus(editorControl);
			SetIsReadOnly(editorControl);

            Control.ViewAttachedToWindow += Control_ViewAttachedToWindow;
            //Control.Touch += Control_Touch;
            //Control.FocusChange += Control_FocusChange;
        }


        
        void HideSoftKeyBoardOnTextChanged(  MvvmAspire.Controls.Editor element)
        {
            if (element.IsFocused && BaseElement.SuppressKeyboard)
            {
                UIHelper.CloseSoftKeyboard(Control);
            }

            //if (string.IsNullOrWhiteSpace(Element.Text))
            //    Control.Text = "";
            //else
            //    Control.Text = element.Text;
            
        }

        void SetShowSoftInputOnFocus(  MvvmAspire.Controls.Editor element)
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

        void Control_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            if (e.HasFocus && BaseElement.SuppressKeyboard)
            {
                UIHelper.CloseSoftKeyboard(Control);
            }
        }

        async void Control_ViewAttachedToWindow(object sender, ViewAttachedToWindowEventArgs e)
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

        void SetTextAlignment(  MvvmAspire.Controls.Editor element)
        {
            switch (element.TextAlignment)
            {
                case   MvvmAspire.TextAlignment.Justified:
                case   MvvmAspire.TextAlignment.Left:
                    Control.Gravity = GravityFlags.AxisPullBefore | GravityFlags.AxisSpecified | GravityFlags.Top | GravityFlags.RelativeLayoutDirection; break;
                case   MvvmAspire.TextAlignment.Center:
                    Control.Gravity = GravityFlags.CenterHorizontal | GravityFlags.Top; break;
                case   MvvmAspire.TextAlignment.Right:
                    Control.Gravity = GravityFlags.Top | GravityFlags.Right; break;
            }
        }

        void SetBackground(  MvvmAspire.Controls.Editor element)
        {
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
                        Control.SetBackgroundDrawable(originalBackground);
                }
            }
            else
            {
                if (!hasSetOriginal)
                    Control.SetBackgroundDrawable(originalBackground);
            }
        }

        void SetTypeface(  MvvmAspire.Controls.Editor element)
        {
            if (!string.IsNullOrEmpty(element.FontFamily))
                Control.Typeface = FontCache.GetTypeFace(element.FontFamily);
        }

        void SetTextSize(  MvvmAspire.Controls.Editor element)
        {
            Control.TextSize = (float)element.FontSize;
        }
        
		void SetIsReadOnly(  MvvmAspire.Controls.Editor element)
		{
			if (element.IsReadOnly)
				base.Control.KeyListener = null;
			else
				base.Control.KeyListener = DefaultKeyListener;
		}
    }
}