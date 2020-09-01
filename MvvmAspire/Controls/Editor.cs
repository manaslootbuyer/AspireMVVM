  
using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Editor : Xamarin.Forms.Editor
    {
        /// <summary>
        /// Default Editor padding.
        /// </summary>
        public static readonly Thickness DefaultPadding = Device.RuntimePlatform == Device.iOS ? new Thickness(0) : new Thickness(12d, 8d);

        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(Editor), null);

        public static BindableProperty MaxHeightProperty =
            BindableProperty.Create("MaxHeight", typeof(double?), typeof(Editor), null);

        public static BindableProperty MinHeightProperty =
            BindableProperty.Create("MinHeight", typeof(double?), typeof(Editor), null);

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(Editor), FontStyle.Regular);

        public static BindableProperty TextAlignmentProperty =
            BindableProperty.Create("TextAlignment", typeof(TextAlignment), typeof(Editor), TextAlignment.Left);

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(Editor), "");

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(Editor), Color.Default);

        public static BindableProperty IsReadOnlyProperty =
            BindableProperty.Create("IsReadOnly", typeof(bool), typeof(Editor), false);

        public static BindableProperty EnableAutoCorrectProperty =
            BindableProperty.Create("EnableAutoCorrect", typeof(bool), typeof(Editor), true);

        public static BindableProperty InputAccessoryBackgroundColorProperty =
            BindableProperty.Create("InputAccessoryBackgroundColor", typeof(Color), typeof(Editor), Color.White);

        public static BindableProperty SuppressKeyboardProperty =
            BindableProperty.Create("SuppressKeyboard", typeof(bool), typeof(Editor), false);

        public static BindableProperty MaxCharacterProperty =
            BindableProperty.Create("MaxCharacter", typeof(int?), typeof(Editor), null);

        public static BindableProperty PlaceHolderColorProperty =
              BindableProperty.Create("PlaceHolderColor", typeof(Color), typeof(Editor), Color.Default);


        public Color PlaceHolderColor
        {
            get { return (Color)GetValue(PlaceHolderColorProperty); }
            set { SetValue(PlaceHolderColorProperty, value); }
        }



        /// <summary>
        /// Gets or sets the image or resource to be used as the background of the entry.
        /// </summary>
        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the horizontal alignment of the text.
        /// </summary>
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        /// <summary>
        /// Gets or set the placeholder text of editor. Currently implemented in windows.shared only
        /// </summary>
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
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

        public Color InputAccessoryBackgroundColor
        {
            get { return (Color)GetValue(InputAccessoryBackgroundColorProperty); }
            set { SetValue(InputAccessoryBackgroundColorProperty, value); }
        }

        public double? MaxHeight
        {
            get { return (double?)GetValue(MaxHeightProperty); }
            set { SetValue(MaxHeightProperty, value); }
        }

        public double? MinHeight
        {
            get { return (double?)GetValue(MinHeightProperty); }
            set { SetValue(MinHeightProperty, value); }
        }

        ///// <summary>
        ///// Gets or sets the color of the text.
        ///// </summary>
        //public Color TextColor
        //{
        //    get { return (Color)GetValue(TextColorProperty); }
        //    set { SetValue(TextColorProperty, value); }
        //}

        /// <summary>
        /// Gets or sets if the soft keyboard should be suppressed when entry gets focus.
        /// </summary>
        public bool SuppressKeyboard
        {
            get { return (bool)GetValue(SuppressKeyboardProperty); }
            set { SetValue(SuppressKeyboardProperty, value); }
        }

        public int? MaxCharacter
        {
            get { return (int?)GetValue(MaxCharacterProperty); }
            set { SetValue(MaxCharacterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the padding within the entry. Not implemented, use TextAlignment for placement instead.
        /// </summary>
        //public Thickness Padding
        //{
        //    get { return (Thickness)GetValue(PaddingProperty); }
        //    set { SetValue(PaddingProperty, value); }
        //}

        public Editor()
        {
            //SetFontFamily();
            //this.PropertyChanged += (s, e) =>
            //{
            //    if (e.PropertyName == "FontStyle")
            //        SetFontFamily();
            //};
        }

     

        //public void PerformKeyPress(KeyCode key)
        //{
        //    if (this.onPerformKeyPress != null)
        //        this.onPerformKeyPress(key);
        //}

        //protected void SetFontFamily()
        //{
        //    var fontService = Resolver.Get<IFontService>();
        //    if (fontService == null) return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}
    }
}
