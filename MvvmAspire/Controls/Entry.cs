  
using  MvvmAspire;
using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Entry : Xamarin.Forms.Entry
    {
        /// <summary>
        /// Default entry padding.
        /// </summary>
        public static readonly Thickness DefaultPadding = Device.RuntimePlatform == Device.iOS ? new Thickness(0) : new Thickness(12d, 8d);

        /// <summary>
        /// Default text padding.
        /// </summary>
        public static readonly Thickness DefaultTextPadding = new Thickness(0);

        public static BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(string), typeof(Entry), "true");

        public static BindableProperty MaxCharacterProperty =
            BindableProperty.Create("MaxCharacter", typeof(int?), typeof(Entry), null);

        public static BindableProperty DisabledTextColorProperty =
            BindableProperty.Create("DisabledTextColor", typeof(Color), typeof(Entry), Color.Default);

        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(Entry), null);

     
        public static BindableProperty ImageLeftWidthProperty =
            BindableProperty.Create("ImageLeftWidth", typeof(double), typeof(Entry), 0d);

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(Entry), FontStyle.Regular);

        public static BindableProperty TextPaddingProperty =
            BindableProperty.Create("TextPadding", typeof(Thickness), typeof(Entry), DefaultTextPadding);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(Entry), DefaultPadding);

 
        public static BindableProperty SuppressKeyboardProperty =
            BindableProperty.Create("SuppressKeyboard", typeof(bool), typeof(Entry), false);

        public static BindableProperty IsRightToLeftProperty =
            BindableProperty.Create("IsRightToLeft", typeof(bool), typeof(Entry), false);


        public static BindableProperty ClearFocusProperty =
            BindableProperty.Create("ClearFocus", typeof(bool), typeof(Entry), false);

        public static BindableProperty ClearFocusTriggerProperty =
            BindableProperty.Create("ClearFocusTrigger", typeof(int), typeof(Entry), 0);

        public static BindableProperty NextElementProperty =
            BindableProperty.Create("NextElement", typeof(VisualElement), typeof(Entry), null);

        public static BindableProperty ReturnKeyTypeProperty =
            BindableProperty.Create("ReturnKeyType", typeof(ReturnKeyType), typeof(Entry), ReturnKeyType.Automatic);

        public static BindableProperty TextInputTypeProperty =
            BindableProperty.Create("TextInputType", typeof(TextInputType), typeof(Entry), TextInputType.None);



        public static BindableProperty ImageLeftProperty =
            BindableProperty.Create("ImageLeft", typeof(FileImageSource), typeof(Entry), null);

        public static BindableProperty ImageTopProperty =
            BindableProperty.Create("ImageTop", typeof(FileImageSource), typeof(Entry), null);

        public static BindableProperty ImageRightProperty =
            BindableProperty.Create("ImageRight", typeof(FileImageSource), typeof(Entry), null);

        public static BindableProperty ImageBottomProperty =
            BindableProperty.Create("ImageBottom", typeof(FileImageSource), typeof(Entry), null);

        public static BindableProperty ImageCenterProperty =
            BindableProperty.Create("ImageCenter", typeof(FileImageSource), typeof(Entry), null);

        public static BindableProperty BorderRadiusProperty =
            BindableProperty.Create("BorderRadius", typeof(float), typeof(Entry), 1f);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(Entry), Color.Default);

        public static BindableProperty IsReadOnlyProperty =
            BindableProperty.Create("IsReadOnly", typeof(bool), typeof(Entry), false);

        public static BindableProperty IsSingleLineProperty =
            BindableProperty.Create("IsSingleLine", typeof(bool), typeof(Entry), false);

        public static BindableProperty AccesibilityIgnoreNameWhenNotEmptyProperty =
            BindableProperty.Create("AccesibilityIgnoreNameWhenNotEmpty", typeof(bool), typeof(Entry), false);

        public static BindableProperty AccesibilitySetFocusProperty =
            BindableProperty.Create("AccesibilitySetFocus", typeof(bool), typeof(Entry), false,BindingMode.TwoWay);

        /// <summary>
        /// Identifies the command bound property.
        /// </summary>
        public static BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(Entry), null);


        public event EventHandler DoneClickedEvent = delegate { };

        public void OnDoneClickedEvent(object sender)
        {
            DoneClickedEvent?.Invoke(sender, null);
        }

     

        public static BindableProperty ShowDoneButtonProperty =
            BindableProperty.Create("ShowDoneButton", typeof(bool), typeof(Entry), false);

      
        /// <summary>
        /// Gets or sets the image or resource displayed on the left side of the text.
        /// </summary>
        public float BorderRadius
        {
            get { return (float)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        /// <summary>
        /// Gets or set the border color of the entry. Currently implemented in windows.shared only
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// get or set if entry is editable. It does not change the color to disabled.
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        /// <summary>
        /// get or set if entry is editable. It does not change the color to disabled.
        /// </summary>
        public bool IsSingleLine
        {
            get { return (bool)GetValue(IsSingleLineProperty); }
            set { SetValue(IsSingleLineProperty, value); }
        }

        /// <summary>
        /// get or set if entry should ignore the title or placeholder name when it has content (for 508 )
        /// </summary>
        public bool AccesibilityIgnoreNameWhenNotEmpty
        {
            get { return (bool)GetValue(AccesibilityIgnoreNameWhenNotEmptyProperty); }
            set { SetValue(AccesibilityIgnoreNameWhenNotEmptyProperty, value); }
        }

        public bool AccesibilitySetFocus
        {
            get { return (bool)GetValue(AccesibilitySetFocusProperty); }
            set { SetValue(AccesibilitySetFocusProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed on the left side of the text.
        /// </summary>
        public FileImageSource ImageLeft
        {
            get { return (FileImageSource)GetValue(ImageLeftProperty); }
            set { SetValue(ImageLeftProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed on top of the text.
        /// </summary>
        public FileImageSource ImageTop
        {
            get { return (FileImageSource)GetValue(ImageTopProperty); }
            set { SetValue(ImageTopProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed on the right side of the text.
        /// </summary>
        public FileImageSource ImageRight
        {
            get { return (FileImageSource)GetValue(ImageRightProperty); }
            set { SetValue(ImageRightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed below the text.
        /// </summary>
        public FileImageSource ImageBottom
        {
            get { return (FileImageSource)GetValue(ImageBottomProperty); }
            set { SetValue(ImageBottomProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed at the center.
        /// </summary>
        public FileImageSource ImageCenter
        {
            get { return (FileImageSource)GetValue(ImageCenterProperty); }
            set { SetValue(ImageCenterProperty, value); }
        }


        // Summary:
        //     Gets or sets the command that is run when the menu is clicked.
        //
        // Remarks:
        //     To be added.
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string Tag
        {
            get { return (string)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public int? MaxCharacter
        {
            get { return (int?)GetValue(MaxCharacterProperty); }
            set { SetValue(MaxCharacterProperty, value); }
        }

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }


        /// <summary>
        /// Gets or sets the image or resource to be used as the background of the entry.
        /// </summary>
        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        ///// <summary>
        ///// Gets the font family to which the font for the entry belongs.
        ///// </summary>
        //public string FontFamily
        //{
        //    get { return (string)GetValue(FontFamilyProperty); }
        //    set { SetValue(FontFamilyProperty, value); }
        //}

        ///// <summary>
        ///// Gets the size of the font for the entry.
        ///// </summary>
        //public double FontSize
        //{
        //    get { return (double)GetValue(FontSizeProperty); }
        //    set { SetValue(FontSizeProperty, value); }
        //}

        public double ImageLeftWidth
        {
            get { return (double)GetValue(ImageLeftWidthProperty); }
            set { SetValue(ImageLeftWidthProperty, value); }
        }
        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        //public Thickness Margin
        //{
        //    get { return (Thickness)GetValue(MarginProperty); }
        //    set { SetValue(MarginProperty, value); }
        //}

        public bool IsRightToLeft
        {
            get { return (bool)GetValue(IsRightToLeftProperty); }
            set { SetValue(IsRightToLeftProperty, value); }
        }

        /// <summary>
        /// Gets or sets if the soft keyboard should be suppressed when entry gets focus.
        /// </summary>
        public bool SuppressKeyboard
        {
            get { return (bool)GetValue(SuppressKeyboardProperty); }
            set { SetValue(SuppressKeyboardProperty, value); }
        }

        public int ClearFocusTrigger
        {
            get { return (int)GetValue(ClearFocusTriggerProperty); }
            set { SetValue(ClearFocusTriggerProperty, value); }
        }

        public bool ClearFocus
        {
            get { return (bool)GetValue(ClearFocusProperty); }
            set { SetValue(ClearFocusProperty, value); }
        }

        public IList< MvvmAspire.Controls.Entry> GroupElement { get; protected set; }

        public VisualElement NextElement
        {
            get { return (VisualElement)GetValue(NextElementProperty); }
            set { SetValue(NextElementProperty, value); }
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

        /// <summary>
        /// Gets or sets the padding between the text and image inside the entry.
        /// </summary>
        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// Implemented for WinRT NextElement focus implementation.
        /// </summary>
        internal bool DisableNextFocus { get; set; }


        public bool ShowDoneButton
        {
            get { return (bool)GetValue(ShowDoneButtonProperty); }
            set { SetValue(ShowDoneButtonProperty, value); }
        }

        public Entry()
        {
            //SetFontFamily();
            //this.PropertyChanged += (s, e) =>
            //{
            //    if (e.PropertyName == "FontStyle")
            //        SetFontFamily();
            //};
        }
    

        //protected void SetFontFamily()
        //{
        //    var fontService = Resolver.Get<IFontService>();
        //    if (fontService == null)return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}
    }
}
