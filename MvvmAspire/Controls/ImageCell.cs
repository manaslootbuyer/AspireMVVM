using System;
using Xamarin.Forms;
using  MvvmAspire.Services;
  

namespace  MvvmAspire.Controls
{
    public class ImageCell : Xamarin.Forms.ImageCell
    {
        public static new readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(ImageCell), null);

        public static readonly BindableProperty ImagePlaceholderProperty =
            BindableProperty.Create("ImagePlaceholder", typeof(FileImageSource), typeof(ImageCell), null);

        public static readonly BindableProperty RenderCircleProperty =
            BindableProperty.Create("RenderCircle", typeof(bool), typeof(ImageCell), false);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create("ImageWidth", typeof(double), typeof(ImageCell), 60d);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create("ImageHeight", typeof(double), typeof(ImageCell), 60d);

        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(ImageCell), 10d);

        public static readonly BindableProperty TextFontFamilyProperty =
            BindableProperty.Create("TextFontFamily", typeof(string), typeof(ImageCell), null);

        public static readonly BindableProperty TextFontSizeProperty =
            BindableProperty.Create("TextFontSize", typeof(double), typeof(ImageCell), Device.GetNamedSize(NamedSize.Default, typeof(Xamarin.Forms.Entry)));

        //public static readonly BindableProperty TextFontStyleProperty =
            //BindableProperty.Create("TextFontStyle", typeof(FontStyle), typeof(ImageCell), FontStyle.Bold);

        public static readonly BindableProperty DetailFontFamilyProperty =
            BindableProperty.Create("DetailFontFamily", typeof(string), typeof(ImageCell), null);

        public static readonly BindableProperty DetailFontSizeProperty =
            BindableProperty.Create("DetailFontSize", typeof(double), typeof(ImageCell), Device.GetNamedSize(NamedSize.Default, typeof(Xamarin.Forms.Entry)));

        //public static readonly BindableProperty DetailFontStyleProperty =
            //BindableProperty.Create("DetailFontStyle", typeof(FontStyle), typeof(ImageCell), FontStyle.Regular);

        public ImageCell()
        {
            SetFontFamily();

            PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case "TextFontStyle":
                    case "DetailFontStyle":
                        SetFontFamily();
                        break;
                }
            };
        }

        /// <summary>
        /// Gets or sets the ImageSource from which the Image is loaded. This is a bindable property.
        /// </summary>
        public new ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the image placeholder.
        /// </summary>
        public FileImageSource ImagePlaceholder
        {
            get { return (FileImageSource)GetValue(ImagePlaceholderProperty); }
            set
            {
                SetValue(ImagePlaceholderProperty, value);
                SetValue(Xamarin.Forms.ImageCell.ImageSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets whether the image displayed is in circle state.
        /// </summary>
        public bool RenderCircle
        {
            get { return (bool)GetValue(RenderCircleProperty); }
            set { SetValue(RenderCircleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font family to which the font for the Text belongs.
        /// </summary>
        public string TextFontFamily
        {
            get { return (string)GetValue(TextFontFamilyProperty); }
            set { SetValue(TextFontFamilyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the font for the Text.
        /// </summary>
        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the Text.
        /// </summary>
        //public FontStyle TextFontStyle
        //{
        //    get { return (FontStyle)GetValue(TextFontStyleProperty); }
        //    set { SetValue(TextFontStyleProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the text color for the Text.
        /// </summary>
        //public Color TextColor
        //{
        //    get { return (Color)GetValue(TextColorProperty); }
        //    set { SetValue(TextColorProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the font family to which the font for the Detail belongs.
        /// </summary>
        public string DetailFontFamily
        {
            get { return (string)GetValue(DetailFontFamilyProperty); }
            set { SetValue(DetailFontFamilyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the font for the Detail.
        /// </summary>
        public double DetailFontSize
        {
            get { return (double)GetValue(DetailFontSizeProperty); }
            set { SetValue(DetailFontSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the Detail.
        /// </summary>
        //public FontStyle DetailFontStyle
        //{
        //    get { return (FontStyle)GetValue(DetailFontStyleProperty); }
        //    set { SetValue(DetailFontStyleProperty, value); }
        //}

        protected void SetFontFamily()
        {
            //var fontService = Resolver.Get<IFontService>();
            //if (fontService == null) return;

            //TextFontFamily = fontService.GetFontName(TextFontStyle);
            //DetailFontFamily = fontService.GetFontName(DetailFontStyle);
        }

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
    }
}

