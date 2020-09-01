using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class TabChild : ContentView
    {

        public static readonly Thickness DefaultTextPadding = Device.RuntimePlatform == Device.iOS ? new Thickness(5) : new Thickness(5, 5, 10, 5);

        public static BindableProperty ImageRightHeightProperty =
            BindableProperty.Create("ImageRightHeight", typeof(double), typeof(TabChild), Double.NaN);

        public static BindableProperty ImageRightWidthProperty =
            BindableProperty.Create("ImageRightWidth", typeof(double), typeof(TabChild), Double.NaN);

        public static BindableProperty ImageLeftHeightProperty =
            BindableProperty.Create("ImageLeftHeight", typeof(double), typeof(TabChild), Double.NaN);

        public static BindableProperty ImageLeftWidthProperty =
            BindableProperty.Create("ImageLeftWidth", typeof(double), typeof(TabChild), Double.NaN);

        public static BindableProperty RefitTextEnabledProperty =
            BindableProperty.Create("RefitTextEnabled", typeof(bool), typeof(TabChild), false);

        public static BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(Thickness), typeof(TabChild), new Thickness(0));

        public static BindableProperty TextPaddingProperty =
            BindableProperty.Create("TextPadding", typeof(Thickness), typeof(TabChild), DefaultTextPadding);

        public static BindableProperty ImageRightProperty =
            BindableProperty.Create("ImageRight", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty SelectedImageRightProperty =
            BindableProperty.Create("SelectedImageRight", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty SelectedImageLeftProperty =
            BindableProperty.Create("SelectedImageLeft", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty ImageLeftProperty =
            BindableProperty.Create("ImageLeft", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty MinimumFontSizeProperty =
            BindableProperty.Create("MinimumFontSize", typeof(double), typeof(TabChild), 8.1d);

        public static BindableProperty ColumnWidthProperty =
            BindableProperty.Create("ColumnWidth", typeof(GridLength), typeof(TabChild), new GridLength(1, GridUnitType.Star));

        public static BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(TabChild), "");

        public static BindableProperty SubTextProperty =
            BindableProperty.Create("SubText", typeof(string), typeof(TabChild), "");

        public static BindableProperty SetCurrentSelectedProperty =
            BindableProperty.Create("SetCurrentSelected", typeof(bool), typeof(TabChild), false);

        public static BindableProperty CenterImageProperty =
            BindableProperty.Create("CenterImage", typeof(bool), typeof(TabChild), false);

        public static BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(TabChild), Color.White);

        public static BindableProperty SubTextColorProperty =
            BindableProperty.Create("SubTextColor", typeof(Color), typeof(TabChild), Color.Default);

        public static BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(TabChild), 5.4d);

        public static BindableProperty SubTextFontSizeProperty =
            BindableProperty.Create("SubTextFontSize", typeof(double), typeof(TabChild), 4.5d);

        //public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(TabChild), FontStyle.Regular);

        public static BindableProperty SelectedBackgroundImageProperty =
            BindableProperty.Create("SelectedBackgroundImage", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create("SelectedBackgroundColor", typeof(Color), typeof(TabChild), Color.Transparent);

        public static BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(TabChild), null);

        public static BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(object), typeof(TabChild), null);

        public static BindableProperty BorderRadiusProperty =
            BindableProperty.Create("BorderRadius", typeof(int), typeof(TabChild), 0);

        public static readonly BindableProperty AnimateTabSwitchProperty =
            BindableProperty.Create("AnimateTabSwitch", typeof(bool), typeof(TabChild), true);

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create("SelectedTextColor", typeof(Color), typeof(TabChild), Color.White);


        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }


        public GridLength ColumnWidth
        {
            get { return (GridLength)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string SubText
        {
            get { return (string)GetValue(SubTextProperty); }
            set { SetValue(SubTextProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Color SubTextColor
        {
            get { return (Color)GetValue(SubTextColorProperty); }
            set { SetValue(SubTextColorProperty, value); }
        }

        public bool SetCurrentSelected
        {
            get { return (bool)GetValue(SetCurrentSelectedProperty); }
            set { SetValue(SetCurrentSelectedProperty, value); }
        }

        /// <summary>
        /// Set if image is center aligned. For android use only
        /// </summary>
        public bool CenterImage
        {
            get { return (bool)GetValue(CenterImageProperty); }
            set { SetValue(CenterImageProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public double SubTextFontSize
        {
            get { return (double)GetValue(SubTextFontSizeProperty); }
            set { SetValue(SubTextFontSizeProperty, value); }
        }

        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        public FileImageSource SelectedBackgroundImage
        {
            get { return (FileImageSource)GetValue(SelectedBackgroundImageProperty); }
            set { SetValue(SelectedBackgroundImageProperty, value); }
        }

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public object Tag
        {
            get { return (object)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public int BorderRadius
        {
            get { return (int)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        public bool AnimateTabSwitch
        {
            get { return (bool)GetValue(AnimateTabSwitchProperty); }
            set { SetValue(AnimateTabSwitchProperty, value); }
        }

        public void SetSelected()
        {
            IsVisible = true;

            if (Content is TabChildContentView)
                ((TabChildContentView)Content).Show();

            //if (Opacity < 1)
            //{
            //    if (this.AnimateTabSwitch)
            //    {
            //        this.Animate("toggleTabVisibilityAnimation", new Animation((double d) =>
            //        {
            //            Opacity = d;
            //        }, 0, 1, Easing.BounceIn));
            //    }
            //    else
            //    {
            //        Opacity = 1;
            //    }
            //}
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
            {
                SetSelected();
            }
            else
            {
                //if (this.AnimateTabSwitch)
                //{
                //    this.Animate("toggleTabVisibilityAnimation", new Animation((double d) =>
                //    {
                //        Opacity = d;
                //    }, 1, 0, Easing.Linear), finished: (d, r) =>
                //    {
                //        if (!r)
                //            IsVisible = false;
                //    });
                //}
                //else
                //{
                //    this.Opacity = 0;
                //    this.IsVisible = false;
                //}

                if (Content is TabChildContentView)
                    ((TabChildContentView)Content).Hide();
            }
        }

        public Thickness CornerRadius
        {
            get { return (Thickness)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public Thickness TextPadding
        {
            get { return (Thickness)GetValue(TextPaddingProperty); }
            set { SetValue(TextPaddingProperty, value); }
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

        public bool RefitTextEnabled
        {
            get { return (bool)GetValue(RefitTextEnabledProperty); }
            set { SetValue(RefitTextEnabledProperty, value); }
        }

        public double MinimumFontSize
        {
            get { return (double)GetValue(MinimumFontSizeProperty); }
            set { SetValue(MinimumFontSizeProperty, value); }
        }
    }
}
