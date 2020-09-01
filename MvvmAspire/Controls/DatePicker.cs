using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class DatePicker : Xamarin.Forms.DatePicker
    {

        public DatePicker()
        {

        }

        public DateTime? DateTag
        {
            get { return (DateTime?)GetValue(DateTagProperty); }
            set { SetValue(DateTagProperty, value); }
        }

        public int TriggerShowDatePicker
        {
            get { return (int)GetValue(TriggerShowDatePickerProperty); }
            set { SetValue(TriggerShowDatePickerProperty, value); }
        }

        public TextAlignment XAlign
        {
            get { return (TextAlignment)GetValue(XAlignProperty); }
            set { SetValue(XAlignProperty, value); }
        }

        public TextAlignment YAlign
        {
            get { return (TextAlignment)GetValue(YAlignProperty); }
            set { SetValue(YAlignProperty, value); }
        }

     
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(DatePicker), FontStyle.Light);



        public static BindableProperty XAlignProperty =
            BindableProperty.Create("XAlign", typeof(TextAlignment), typeof(DatePicker), TextAlignment.Right);

        public static BindableProperty YAlignProperty =
            BindableProperty.Create("YAlign", typeof(TextAlignment), typeof(DatePicker), TextAlignment.Center);

        public static BindableProperty TriggerShowDatePickerProperty =
            BindableProperty.Create("TriggerShowDatePicker", typeof(int), typeof(DatePicker), 0);

        public static BindableProperty DateTagProperty =
            BindableProperty.Create("DateTag", typeof(DateTime?), typeof(DatePicker), null);

        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(DatePicker), null);

        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }
    }
}
