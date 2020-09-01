  
using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Button : Xamarin.Forms.Button
    {
        /// <summary>
        /// Default button padding.
        /// </summary>
        public static readonly Thickness DefaultPadding = new Thickness(0);

        /// <summary>
        /// Default text padding.
        /// </summary>
        public static readonly Thickness DefaultTextPadding = new Thickness(0);

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(Button), FontStyle.Regular);

        public static BindableProperty DisabledTextColorProperty =
            BindableProperty.Create("DisabledTextColor", typeof(Color), typeof(Button), Color.Default);

        public static BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create("DisabledBackgroundColor", typeof(Color), typeof(Button), Color.Default);

        public static BindableProperty CornerProperty =
            BindableProperty.Create("Corner", typeof(Thickness), typeof(Button), new Thickness(0));

        public static BindableProperty ImageHeightProperty =
            BindableProperty.Create("ImageHeight", typeof(double), typeof(Button), 20d);

        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(Button));

        public static BindableProperty HighlightedBackgroundImageProperty =
            BindableProperty.Create("HighlightedBackgroundImage", typeof(FileImageSource), typeof(Button));

        public static BindableProperty BackgroundImagePatternProperty =
            BindableProperty.Create("BackgroundImagePattern", typeof(FileImageSource), typeof(Button));

        public static BindableProperty HighlightedBackgroundImagePatternProperty =
            BindableProperty.Create("HighlightedBackgroundImagePattern", typeof(FileImageSource), typeof(Button));

        public static BindableProperty ImageLeftProperty =
            BindableProperty.Create("ImageLeft", typeof(FileImageSource), typeof(Button));

        public static BindableProperty SelectedImageLeftProperty =
            BindableProperty.Create("SelectedImageLeft", typeof(FileImageSource), typeof(Button));

        public static BindableProperty ImageTopProperty =
            BindableProperty.Create("ImageTop", typeof(FileImageSource), typeof(Button));

        public static BindableProperty ImageRightProperty =
            BindableProperty.Create("ImageRight", typeof(FileImageSource), typeof(Button));

        public static BindableProperty ImageBottomProperty =
            BindableProperty.Create("ImageBottom", typeof(FileImageSource), typeof(Button));

        public static BindableProperty SelectedImageRightProperty =
            BindableProperty.Create("SelectedImageRight", typeof(FileImageSource), typeof(Button));

        public static BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(Button), new Thickness(0));

        public static BindableProperty TextPaddingProperty =
            BindableProperty.Create("TextPadding", typeof(Thickness), typeof(Button), DefaultTextPadding);

        public static BindableProperty ImageRightHeightProperty =
            BindableProperty.Create("ImageRightHeight", typeof(double), typeof(Button), Double.NaN);

        public static BindableProperty ImageRightWidthProperty =
            BindableProperty.Create("ImageRightWidth", typeof(double), typeof(Button), Double.NaN);

        public static BindableProperty ImageLeftHeightProperty =
            BindableProperty.Create("ImageLeftHeight", typeof(double), typeof(Button), Double.NaN);

        public static BindableProperty ImageLeftWidthProperty =
            BindableProperty.Create("ImageLeftWidth", typeof(double), typeof(Button), Double.NaN);

        public static BindableProperty TiltEnabledProperty =
            BindableProperty.Create("TiltEnabled", typeof(bool), typeof(Button), false);

        public static BindableProperty CenterImageProperty =
            BindableProperty.Create("CenterImage", typeof(bool), typeof(Button), false);

        public static BindableProperty RefitTextEnabledProperty =
            BindableProperty.Create("RefitTextEnabled", typeof(bool), typeof(Button), false);

        public static BindableProperty MinimumFontSizeProperty =
            BindableProperty.Create("MinimumFontSize", typeof(double), typeof(Button), 8d);

        public static BindableProperty TextLineBreakModeProperty =
            BindableProperty.Create("TextLineBreakMode", typeof(LineBreakMode), typeof(Button), LineBreakMode.MiddleTruncation);

        public static BindableProperty XAlignProperty =
            BindableProperty.Create("XAlign", typeof(Xamarin.Forms.TextAlignment), typeof(Button), Xamarin.Forms.TextAlignment.Center);

        public static BindableProperty YAlignProperty =
            BindableProperty.Create("YAlign", typeof(Xamarin.Forms.TextAlignment), typeof(Button), Xamarin.Forms.TextAlignment.Center);

        public static BindableProperty BorderlessProperty =
            BindableProperty.Create("Borderless", typeof(bool), typeof(Button), false);

        public static BindableProperty AccesibilitySetNameProperty =
            BindableProperty.Create("AccesibilitySetName", typeof(string), typeof(Button), string.Empty);

        //		public static BindableProperty BorderRadiusProperty =
        //			BindableProperty.Create <Button, double>(p => p.BorderRadius, 0f);


        /// <summary>
        /// Gets or sets the horizontal text alignment.
        /// </summary>
        public Xamarin.Forms.TextAlignment XAlign
        {
            get { return (Xamarin.Forms.TextAlignment)GetValue(XAlignProperty); }
            set { SetValue(XAlignProperty, value); }
        }

        /// <summary>
        /// Gets or sets the vertical text alignment.
        /// </summary>
        public Xamarin.Forms.TextAlignment YAlign
        {
            get { return (Xamarin.Forms.TextAlignment)GetValue(YAlignProperty); }
            set { SetValue(YAlignProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        public Thickness Corner
        {
            get { return (Thickness)GetValue(CornerProperty); }
            set { SetValue(CornerProperty, value); }
        }

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the disabled background.
        /// </summary>
        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets imageheight of drawables. Used in android only
        /// </summary>
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource to be used as the background of the button.
        /// </summary>
        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        /// <summary>
        /// For iOS only. Gets or sets the image or resource to be used as the background of the button when highlighted.
        /// </summary>
        public FileImageSource HighlightedBackgroundImage
        {
            get { return (FileImageSource)GetValue(HighlightedBackgroundImageProperty); }
            set { SetValue(HighlightedBackgroundImageProperty, value); }
        }

        /// <summary>
        /// For iOS only. Gets or sets the image or resource to be used as the background pattern of the button.
        /// </summary>
        public FileImageSource BackgroundImagePattern
        {
            get { return (FileImageSource)GetValue(BackgroundImagePatternProperty); }
            set { SetValue(BackgroundImagePatternProperty, value); }
        }

        /// <summary>
        /// For iOS only. Gets or sets the image or resource to be used as the background pattern of the button when highlighted.
        /// </summary>
        public FileImageSource HighlightedBackgroundImagePattern
        {
            get { return (FileImageSource)GetValue(HighlightedBackgroundImagePatternProperty); }
            set { SetValue(HighlightedBackgroundImagePatternProperty, value); }
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

        public string AccesibilitySetName
        {
            get { return (string)GetValue(AccesibilitySetNameProperty); }
            set { SetValue(AccesibilitySetNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image or resource displayed below the text.
        /// </summary>
        public FileImageSource ImageBottom
        {
            get { return (FileImageSource)GetValue(ImageBottomProperty); }
            set { SetValue(ImageBottomProperty, value); }
        }

        public FileImageSource SelectedImageRight
        {
            get { return (FileImageSource)GetValue(SelectedImageRightProperty); }
            set { SetValue(SelectedImageRightProperty, value); }
        }

        public FileImageSource SelectedImageLeft
        {
            get { return (FileImageSource)GetValue(SelectedImageLeftProperty); }
            set { SetValue(SelectedImageLeftProperty, value); }
        }
        /// <summary>
        /// Gets or sets the image or resource displayed at the center.
        /// </summary>
        //public FileImageSource ImageCenter
        //{
        //    get { return (FileImageSource)GetValue(ImageCenterProperty); }
        //    set { SetValue(ImageCenterProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the padding within the button.
        /// </summary>
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the padding between the text and image inside the button.
        /// </summary>
        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        public double ImageRightHeight
        {
            get { return (double)GetValue(ImageRightHeightProperty); }
            set { SetValue(ImageRightHeightProperty, value); }
        }

        public double ImageRightWidth
        {
            get { return (double)GetValue(ImageRightWidthProperty); }
            set { SetValue(ImageRightWidthProperty, value); }
        }

        public double ImageLeftHeight
        {
            get { return (double)GetValue(ImageLeftHeightProperty); }
            set { SetValue(ImageLeftHeightProperty, value); }
        }

        public double ImageLeftWidth
        {
            get { return (double)GetValue(ImageLeftWidthProperty); }
            set { SetValue(ImageLeftWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether to use the tilt effect in windows.
        /// Default to true.
        /// </summary>
        public bool TiltEnabled
        {
            get { return (bool)GetValue(TiltEnabledProperty); }
            set { SetValue(TiltEnabledProperty, value); }
        }

        /// <summary>
        /// Set if image is center aligned. For android use only
        /// </summary>
        public bool CenterImage
        {
            get { return (bool)GetValue(CenterImageProperty); }
            set { SetValue(CenterImageProperty, value); }
        }

        /// <summary>
        /// Indicates whether the button's text will resize to fit with the button's width.
        /// </summary>
        public bool RefitTextEnabled
        {
            get { return (bool)GetValue(RefitTextEnabledProperty); }
            set { SetValue(RefitTextEnabledProperty, value); }
        }

        /// <summary>
        /// The minimum font size of the button.
        /// Will be ignored if RefitTextEnabled property is set to false.
        /// </summary>
        public double MinimumFontSize
        {
            get { return (double)GetValue(MinimumFontSizeProperty); }
            set { SetValue(MinimumFontSizeProperty, value); }
        }

        /// <summary>
        /// The line break mode of the button.
        /// </summary>
        public LineBreakMode TextLineBreakMode
        {
            get { return (LineBreakMode)GetValue(TextLineBreakModeProperty); }
            set { SetValue(TextLineBreakModeProperty, value); }
        }

        /// <summary>
        /// Removes border on windows.
        /// </summary>
        public bool Borderless
        {
            get { return (bool)GetValue(BorderlessProperty); }
            set { SetValue(BorderlessProperty, value); }
        }

        public Button()
        {
            //SetFontFamily();
            //this.PropertyChanged += (s, e) =>
            //{
            //    if (e.PropertyName == "FontStyle")
            //        SetFontFamily();
            //};
        }

   //     protected void SetFontFamily()
   //     {
   //         var fontService = Resolver.Get<IFontService>();
			//if (fontService == null) return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}

        public event EventHandler LongPress;

        public void OnLongPress()
        {
            EventHandler handler = LongPress;
            if (handler != null)
                LongPress(this, null);
        }
    }
}
