  
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
    public class FormattedLabelChild : Xamarin.Forms.Label
    {
        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(FormattedLabelChild), FontStyle.Regular);

        public static BindableProperty ClickableIndexProperty =
            BindableProperty.Create("ClickableIndex", typeof(int), typeof(FormattedLabelChild), -1);

        public static BindableProperty TextStyleProperty =
            BindableProperty.Create("TextStyle", typeof(TextStyle), typeof(FormattedLabelChild), TextStyle.None);

        public static BindableProperty UnderlineColorProperty =
            BindableProperty.Create("UnderlineColor", typeof(Color), typeof(FormattedLabelChild), Color.Transparent);

        public static BindableProperty ClickWholeTextProperty =
            BindableProperty.Create("ClickWholeText", typeof(bool), typeof(FormattedLabelChild), false);

        public static BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(FormattedLabelChild), null);

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        public TextStyle TextStyle
        {
            get { return (TextStyle)GetValue(TextStyleProperty); }
            set { SetValue(TextStyleProperty, value); }
        }

        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        public int ClickableIndex
        {
            get { return (int)GetValue(ClickableIndexProperty); }
            set { SetValue(ClickableIndexProperty, value); }
        }

        public Color UnderlineColor
        {
            get { return (Color)GetValue(UnderlineColorProperty); }
            set { SetValue(UnderlineColorProperty, value); }
        }

        public bool ClickWholeText
        {
            get { return (bool)GetValue(ClickWholeTextProperty); }
            set { SetValue(ClickWholeTextProperty, value); }
        }

        public FormattedLabelChild()
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

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
    }
}
