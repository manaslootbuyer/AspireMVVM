using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class XamarinRadioButton : View
    {
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked", typeof(bool), typeof(XamarinRadioButton), false);

        public bool Checked
        {
            get { return (bool)base.GetValue(CheckedProperty); }
            set { 
                base.SetValue(CheckedProperty, value); 
                var eventHandler = this.CheckedChanged;
                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(XamarinRadioButton), string.Empty);

        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }

        public static BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(Label), Color.Default);

        public EventHandler<EventArgs<bool>> CheckedChanged;

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public int Id { get; set; }
    }


}