  
using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class FormattedTextLabel : Xamarin.Forms.Label
    {
        public static BindableProperty DefaultTextColorProperty =
            BindableProperty.Create("DefaultTextColor", typeof(Color), typeof(FormattedTextLabel), Color.White);

        public static BindableProperty HTMLStringProperty =
            BindableProperty.Create("HTMLString", typeof(string), typeof(FormattedTextLabel), null);

        public static BindableProperty DefaultFontSizeProperty =
            BindableProperty.Create("DefaultFontSize", typeof(double), typeof(FormattedTextLabel), 6.3d);

        public static BindableProperty DefaultHFontSizeProperty =
            BindableProperty.Create("DefaultHFontSize", typeof(double), typeof(FormattedTextLabel), -1d);

        public static BindableProperty MaxLinesProperty =
            BindableProperty.Create("MaxLines", typeof(int), typeof(FormattedTextLabel), 0);

        //public static BindableProperty DefaultPFontSizeProperty =
        //    BindableProperty.Create <FormattedTextLabel, double>(l => l.DefaultPFontSize, (double)new PointSize(6));

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(FormattedTextLabel), FontStyle.Regular);

        public new static BindableProperty FontFamilyProperty =
            BindableProperty.Create("FontFamily", typeof(string), typeof(FormattedTextLabel), "");

        public string HTMLString
        {
            get { return (string)GetValue(HTMLStringProperty); }
            set { SetValue(HTMLStringProperty, value); }
        }

        public double DefaultFontSize
        {
            get { return (double)GetValue(DefaultFontSizeProperty); }
            set { SetValue(DefaultFontSizeProperty, value); }
        }

        public double DefaultHFontSize
        {
            get { return (double)GetValue(DefaultHFontSizeProperty); }
            set { SetValue(DefaultHFontSizeProperty, value); }
        }

        public Color DefaultTextColor
        {
            get { return (Color)GetValue(DefaultTextColorProperty); }
            set { SetValue(DefaultTextColorProperty, value); }
        }

        //public double DefaultPFontSize
        //{
        //    get { return (double)GetValue(DefaultPFontSizeProperty); }
        //    set { SetValue(DefaultPFontSizeProperty, value); }
        //}

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        public new string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public FormattedTextLabel()
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
    }
}
