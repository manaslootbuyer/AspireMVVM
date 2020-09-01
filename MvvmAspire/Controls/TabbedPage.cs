using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class TabbedPage : Xamarin.Forms.TabbedPage
    {
        public static readonly BindableProperty TabScreenLocationProperty =
            BindableProperty.Create("TabScreenLocation", typeof(TabGravity), typeof(TabbedPage), TabGravity.Bottom);

        public static readonly BindableProperty TextVisibleProperty =
            BindableProperty.Create("TextVisible", typeof(bool), typeof(TabbedPage), true);

        public static readonly BindableProperty BadgeLocationProperty =
            BindableProperty.Create("BadgeLocation", typeof(int), typeof(TabbedPage), -1);

        public static readonly BindableProperty ShowTabsProperty =
            BindableProperty.Create("ShowTabs", typeof(bool), typeof(TabbedPage), true);

        public static readonly BindableProperty ShowIndicatorProperty =
            BindableProperty.Create("ShowIndicator", typeof(bool), typeof(TabbedPage), true);

        public static readonly BindableProperty BadgeCountProperty =
            BindableProperty.Create("BadgeCount", typeof(int), typeof(TabbedPage), 0);

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create("SelectedTextColor", typeof(Color), typeof(TabbedPage), Color.Default);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(TabbedPage), Color.Default);

        public static readonly BindableProperty TabBackgroundColorProperty =
            BindableProperty.Create("TabBackgroundColor", typeof(Color), typeof(TabbedPage), Color.Default);

        public static readonly BindableProperty BackgroundDrawableProperty =
            BindableProperty.Create("BackgroundDrawable", typeof(FileImageSource), typeof(TabbedPage), null);

        public static readonly BindableProperty SelectedDrawableProperty =
            BindableProperty.Create("SelectedDrawable", typeof(FileImageSource), typeof(TabbedPage), null);

        public static readonly BindableProperty CustomViewBackgroundProperty =
            BindableProperty.Create("CustomViewBackground", typeof(string), typeof(TabbedPage), null);

        public static readonly BindableProperty CustomViewEmptyBackgroundProperty =
            BindableProperty.Create("CustomViewEmptyBackground", typeof(string), typeof(TabbedPage), null);

        public IList<string> ActiveIcons { get; protected set; }

        public event EventHandler<int> TappedIndex = (s, e) => { };

        public void RaiseTappedIndex(int indexNumber)
        {
            this.TappedIndex(this, indexNumber);
        }

        public TabbedPage()
        {
            this.ActiveIcons = new List<string>();
        }

        public TabGravity TabScreenLocation
        {
            get { return (TabGravity)base.GetValue(TabScreenLocationProperty); }
            set { SetValue(TabScreenLocationProperty, value); }
        }

        public bool TextVisible
        {
            get { return (bool)base.GetValue(TextVisibleProperty); }
            set { SetValue(TextVisibleProperty, value); }
        }

        public int BadgeLocation
        {
            get { return (int)base.GetValue(BadgeLocationProperty); }
            set { SetValue(BadgeLocationProperty, value); }
        }

        public bool ShowTabs
        {
            get { return (bool)base.GetValue(ShowTabsProperty); }
            set { SetValue(ShowTabsProperty, value); }
        }

        public bool ShowIndicator
        {
            get { return (bool)base.GetValue(ShowIndicatorProperty); }
            set { SetValue(ShowIndicatorProperty, value); }
        }

        public int BadgeCount
        {
            get { return (int)base.GetValue(BadgeCountProperty); }
            set { SetValue(BadgeCountProperty, value); }
        }

        public Color SelectedTextColor
        {
            get { return (Color)base.GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)base.GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Color TabBackgroundColor
        {
            get { return (Color)base.GetValue(TabBackgroundColorProperty); }
            set { SetValue(TabBackgroundColorProperty, value); }
        }

        public FileImageSource BackgroundDrawable
        {
            get { return (FileImageSource)base.GetValue(BackgroundDrawableProperty); }
            set { SetValue(BackgroundDrawableProperty, value); }
        }

        public FileImageSource SelectedDrawable
        {
            get { return (FileImageSource)base.GetValue(SelectedDrawableProperty); }
            set { SetValue(SelectedDrawableProperty, value); }
        }

        public string CustomViewBackground
        {
            get { return (string)base.GetValue(CustomViewBackgroundProperty); }
            set { SetValue(CustomViewBackgroundProperty, value); }
        }

        public string CustomViewEmptyBackground
        {
            get { return (string)base.GetValue(CustomViewEmptyBackgroundProperty); }
            set { SetValue(CustomViewEmptyBackgroundProperty, value); }
        }
    }
}
