using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using  MvvmAspire.Services;
  

namespace  MvvmAspire.Controls
{
    public class RoundedComboBox : Xamarin.Forms.View
    {
        public event EventHandler Completed;

        public static BindableProperty DisplayTextFieldProperty =
            BindableProperty.Create("DisplayTextField", typeof(string), typeof(RoundedComboBox), "");

        public static BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(RoundedComboBox), "");

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(RoundedComboBox), 6.3d);

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(RoundedComboBox), FontStyle.Regular);

        public static BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(RoundedComboBox), "");

        public static BindableProperty SelectedItemProperty =
            BindableProperty.Create("SelectedItem", typeof(object), typeof(RoundedComboBox), null, BindingMode.TwoWay);

        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create("SelectedIndex", typeof(int), typeof(RoundedComboBox), -1, BindingMode.TwoWay);

        public static BindableProperty ItemCountProperty =
            BindableProperty.Create("ItemCount", typeof(int?), typeof(RoundedComboBox), null);

        public static BindableProperty ItemsPanelBackgroundProperty =
            BindableProperty.Create("ItemsPanelBackground", typeof(Color), typeof(RoundedComboBox), Color.Default);

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(RoundedComboBox), null);

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(RoundedComboBox), "");

        public static BindableProperty PlaceholderColorProperty =
            BindableProperty.Create("PlaceholderColor", typeof(Color), typeof(RoundedComboBox), Color.Default);

        public static BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(RoundedComboBox), Color.Default);

        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedComboBox), 15d);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedComboBox), Color.Default);

        public static BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create("HorizontalTextAlignment", typeof(Xamarin.Forms.TextAlignment), typeof(RoundedComboBox), Xamarin.Forms.TextAlignment.Start);

        public static BindableProperty ImageLeftProperty =
            BindableProperty.Create("ImageLeft", typeof(FileImageSource), typeof(RoundedComboBox), null);

        public static BindableProperty ImageRightProperty =
            BindableProperty.Create("ImageRight", typeof(FileImageSource), typeof(RoundedComboBox), null);

        public static BindableProperty ImageRightWidthProperty =
            BindableProperty.Create("ImageRightWidth", typeof(double), typeof(RoundedComboBox), 20d);

        public static BindableProperty ImageLeftWidthProperty =
            BindableProperty.Create("ImageLeftWidth", typeof(double), typeof(RoundedComboBox), 20d);

        public static BindableProperty ImageLeftHeightProperty =
            BindableProperty.Create("ImageLeftHeight", typeof(double), typeof(RoundedComboBox), 20d);

        public static BindableProperty TextPaddingProperty =
            BindableProperty.Create("TextPadding", typeof(Thickness), typeof(RoundedComboBox), new Thickness(10, 5));

        public static BindableProperty IsDialogVisibleProperty =
            BindableProperty.Create("IsDialogVisible", typeof(bool), typeof(RoundedComboBox), false, BindingMode.OneWayToSource);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayTextField
        {
            get { return (string)GetValue(DisplayTextFieldProperty); }
            set { SetValue(DisplayTextFieldProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
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
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public int? ItemCount
        {
            get { return (int?)GetValue(ItemCountProperty); }
            set { SetValue(ItemCountProperty, value); }
        }
        public Color ItemsPanelBackground
        {
            get { return (Color)GetValue(ItemsPanelBackgroundProperty); }
            set { SetValue(ItemsPanelBackgroundProperty, value); }
        }

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public Xamarin.Forms.TextAlignment HorizontalTextAlignment
        {
            get { return (Xamarin.Forms.TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        public FileImageSource ImageLeft
        {
            get { return (FileImageSource)GetValue(ImageLeftProperty); }
            set { SetValue(ImageLeftProperty, value); }
        }

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

        public double ImageLeftWidth
        {
            get { return (double)GetValue(ImageLeftWidthProperty); }
            set { SetValue(ImageLeftWidthProperty, value); }
        }

        public double ImageLeftHeight
        {
            get { return (double)GetValue(ImageLeftHeightProperty); }
            set { SetValue(ImageLeftHeightProperty, value); }
        }

        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
        }

        public bool IsDialogVisible
        {
            get { return (bool)GetValue(IsDialogVisibleProperty); }
            set { SetValue(IsDialogVisibleProperty, value); }
        }

        public RoundedComboBox()
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
        //    if (fontService == null) return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}

        internal void RaiseCompleted()
        {
            Completed?.Invoke(this, EventArgs.Empty);
        }
    }
}
