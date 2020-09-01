using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using  MvvmAspire.Services;
using System.Windows.Input;
  

namespace  MvvmAspire.Controls
{
    public class RoundedEntry : Xamarin.Forms.Entry
    {
        //public static BindableProperty AndroidTextProperty =
        //    BindableProperty.Create <RoundedEntry, string>(p => p.AndroidText, "", BindingMode.OneWayToSource);

        public static BindableProperty ShouldEndEditingProperty =
            BindableProperty.Create("ShouldEndEditing", typeof(bool), typeof(RoundedEntry), true);

        public static BindableProperty AllowCutCopyPasteProperty =
            BindableProperty.Create("AllowCutCopyPaste", typeof(bool), typeof(RoundedEntry), true);

        public static BindableProperty ShowCursorProperty =
            BindableProperty.Create("ShowCursor", typeof(bool), typeof(RoundedEntry), true);

        public static BindableProperty ShowKeyboardProperty =
            BindableProperty.Create("ShowKeyboard", typeof(bool), typeof(RoundedEntry), false);

        public static BindableProperty TriggerResignResponderProperty =
            BindableProperty.Create("TriggerResignResponder", typeof(int), typeof(RoundedEntry), 0);

        public static BindableProperty TextPaddingProperty =
            BindableProperty.Create("TextPadding", typeof(Thickness), typeof(RoundedEntry), Device.RuntimePlatform== Device.Android? new Thickness(20, 30): new Thickness(10, 5));

        public static BindableProperty IsReadOnlyProperty =
            BindableProperty.Create("IsReadOnly", typeof(bool), typeof(RoundedEntry), false);

        public static BindableProperty EnableAutoCorrectProperty =
            BindableProperty.Create("EnableAutoCorrect", typeof(bool), typeof(RoundedEntry), true);

        public static BindableProperty IsSingleLineProperty =
            BindableProperty.Create("IsSingleLine", typeof(bool), typeof(RoundedEntry), true);

        public static BindableProperty InputAccessoryBackgroundColorProperty =
            BindableProperty.Create("InputAccessoryBackgroundColor", typeof(Color), typeof(RoundedEntry), Color.White);


        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedEntry), 15d);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedEntry), Color.Default);

     
        public static BindableProperty ImageRightProperty =
            BindableProperty.Create("ImageRight", typeof(ImageSource), typeof(RoundedEntry), null);

        public static BindableProperty ImageRightWidthProperty =
            BindableProperty.Create("ImageRightWidth", typeof(double), typeof(RoundedEntry), 20d);

        public static BindableProperty ImageRightHeightProperty =
            BindableProperty.Create("ImageRightHeight", typeof(double), typeof(RoundedEntry), 20d);

       
        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(RoundedEntry), FontStyle.Regular);

        //public static BindableProperty FontFamilyProperty =
        //    BindableProperty.Create <RoundedEntry, string>(p => p.FontFamily, "");

        public static BindableProperty MaxCharacterProperty =
            BindableProperty.Create("MaxCharacter", typeof(int?), typeof(RoundedEntry), null);

        public static BindableProperty NextElementProperty =
            BindableProperty.Create("NextElement", typeof(VisualElement), typeof(RoundedEntry), null);

        public static BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(RoundedEntry), null);

        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(RoundedEntry), null);

        public static BindableProperty ReturnKeyTypeProperty =
            BindableProperty.Create("ReturnKeyType", typeof(ReturnKeyType), typeof(RoundedEntry), ReturnKeyType.Automatic);

        public static BindableProperty TextInputTypeProperty =
            BindableProperty.Create("TextInputType", typeof(TextInputType), typeof(RoundedEntry), TextInputType.None);

        public static BindableProperty TriggerFocusProperty =
            BindableProperty.Create("TriggerFocus", typeof(int), typeof(RoundedEntry), 0);

        public static BindableProperty ShowDoneButtonProperty =
            BindableProperty.Create("ShowDoneButton", typeof(bool), typeof(RoundedEntry), false);

        //public string AndroidText
        //{
        //    get { return (string)GetValue(AndroidTextProperty); }
        //    set { SetValue(AndroidTextProperty, value); }
        //}

        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        /// <summary>
        /// For ios only
        /// </summary>
        public bool EnableAutoCorrect
        {
            get { return (bool)GetValue(EnableAutoCorrectProperty); }
            set { SetValue(EnableAutoCorrectProperty, value); }
        }

        public bool ShouldEndEditing
        {
            get { return (bool)GetValue(ShouldEndEditingProperty); }
            set { SetValue(ShouldEndEditingProperty, value); }
        }

        public bool AllowCutCopyPaste
        {
            get { return (bool)GetValue(AllowCutCopyPasteProperty); }
            set { SetValue(AllowCutCopyPasteProperty, value); }
        }

        public bool ShowCursor
        {
            get { return (bool)GetValue(ShowCursorProperty); }
            set { SetValue(ShowCursorProperty, value); }
        }


        public bool ShowKeyboard
        {
            get { return (bool)GetValue(ShowKeyboardProperty); }
            set { SetValue(ShowKeyboardProperty, value); }
        }


        public bool IsSingleLine
        {
            get { return (bool)GetValue(IsSingleLineProperty); }
            set { SetValue(IsSingleLineProperty, value); }
        }

        public Color InputAccessoryBackgroundColor
        {
            get { return (Color)GetValue(InputAccessoryBackgroundColorProperty); }
            set { SetValue(InputAccessoryBackgroundColorProperty, value); }
        }

        //public bool IsPassword
        //{
        //    get { return (bool)GetValue(IsPasswordProperty); }
        //    set { SetValue(IsPasswordProperty, value); }
        //}

        //public string Placeholder
        //{
        //    get { return (string)GetValue(PlaceholderProperty); }
        //    set { SetValue(PlaceholderProperty, value); }
        //}

        //public Color PlaceholderColor
        //{
        //    get { return (Color)GetValue(PlaceholderColorProperty); }
        //    set { SetValue(PlaceholderColorProperty, value); }
        //}

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        //public Color TextColor
        //{
        //    get { return (Color)GetValue(TextColorProperty); }
        //    set { SetValue(TextColorProperty, value); }
        //}

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        //public Xamarin.Forms.TextAlignment HorizontalTextAlignment
        //{
        //    get { return (Xamarin.Forms.TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
        //    set { SetValue(HorizontalTextAlignmentProperty, value); }
        //}

        public FileImageSource ImageRight
        {
            get { return (FileImageSource)GetValue(ImageRightProperty); }
            set { SetValue(ImageRightProperty, value); }
        }

        public double ImageRightWidth
        {
            get { return (double)GetValue(ImageRightWidthProperty); }
            set { SetValue(ImageRightWidthProperty, value); }
        }

        public double ImageRightHeight
        {
            get { return (double)GetValue(ImageRightHeightProperty); }
            set { SetValue(ImageRightHeightProperty, value); }
        }

        //public double FontSize
        //{
        //    get { return (double)GetValue(FontSizeProperty); }
        //    set { SetValue(FontSizeProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        //public string FontFamily
        //{
        //    get { return (string)GetValue(FontFamilyProperty); }
        //    set { SetValue(FontFamilyProperty, value); }
        //}

        public int? MaxCharacter
        {
            get { return (int?)GetValue(MaxCharacterProperty); }
            set { SetValue(MaxCharacterProperty, value); }
        }

        public int TriggerResignResponder
        {
            get { return (int)GetValue(TriggerResignResponderProperty); }
            set { SetValue(TriggerResignResponderProperty, value); }
        }

        public VisualElement NextElement
        {
            get { return (VisualElement)GetValue(NextElementProperty); }
            set { SetValue(NextElementProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ReturnKeyType ReturnKeyType
        {
            get { return (ReturnKeyType)GetValue(ReturnKeyTypeProperty); }
            set { SetValue(ReturnKeyTypeProperty, value); }
        }

        public TextInputType TextInputType
        {
            get { return (TextInputType)GetValue(TextInputTypeProperty); }
            set { SetValue(TextInputTypeProperty, value); }
        }

        public int TriggerFocus
        {
            get { return (int)GetValue(TriggerFocusProperty); }
            set { SetValue(TriggerFocusProperty, value); }
        }

        /// <summary>
        /// iOS only
        /// </summary>
        /// <value><c>true</c> if show done button; otherwise, <c>false</c>.</value>
        public bool ShowDoneButton
        {
            get { return (bool)GetValue(ShowDoneButtonProperty); }
            set { SetValue(ShowDoneButtonProperty, value); }
        }

        internal bool DisableNextFocus { get; set; }

        public RoundedEntry()
        {
            //SetFontFamily();
            //this.PropertyChanged += (s, e) =>
            //{
                //if (e.PropertyName == "FontStyle")
                    //SetFontFamily();
            //};
        }

       

        public void FocusFixed()
        {
            if (Device.RuntimePlatform == Device.WPF)
            {
                TriggerFocus += 1;
            }
            else
                Focus();
        }

        //protected void SetFontFamily()
        //{
        //    var fontService = Resolver.Get<IFontService>();
        //    if (fontService == null) return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}
    }
}
