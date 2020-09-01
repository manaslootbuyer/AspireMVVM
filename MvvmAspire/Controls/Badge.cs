﻿using System;
using Xamarin.Forms;
using  MvvmAspire.Services;

namespace  MvvmAspire.Controls
{
    public class Badge : Grid
    {
        readonly RoundedBoxView box;
        readonly Label label;

        public static readonly BindableProperty StrokeColorProperty =
            BindableProperty.Create("StrokeColor", typeof(Color), typeof(Badge), Color.White);

        public static readonly BindableProperty BoxColorProperty =
            BindableProperty.Create("BoxColor", typeof(Color), typeof(Badge), Color.Red);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(Badge), "");

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create("TextSize", typeof(double), typeof(Badge), 30);

        public Color StrokeColor
        {
            get { return (Color)GetValue(StrokeColorProperty); }
            set { SetValue(StrokeColorProperty, value); }
        }

        public Color BoxColor
        {
            get { return (Color)GetValue(BoxColorProperty); }
            set { SetValue(BoxColorProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public Badge(double size)
        {
            HeightRequest = size;
            WidthRequest = size;

            box = new RoundedBoxView();
            box.CornerRadius = HeightRequest / 2;
            box.StrokeThickness = 2d;
            box.SetBinding(RoundedBoxView.StrokeProperty, new Binding("StrokeColor", source: this));
            box.SetBinding(VisualElement.BackgroundColorProperty, new Binding("BoxColor", source: this));
            Children.Add(box);

            label = new  MvvmAspire.Controls.Label();
            label.SetBinding(Xamarin.Forms.Label.TextProperty, new Binding("Text", source: this));
            label.SetBinding(Xamarin.Forms.Label.FontSizeProperty, new Binding("TextSize", source: this));
            label.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center;
            label.VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center;
            label.FontAttributes = FontAttributes.Bold;
            label.HorizontalOptions = LayoutOptions.Center;
            Children.Add(label);
            // Auto-width
            SetBinding(VisualElement.WidthRequestProperty, new Binding("Text", BindingMode.OneWay,
                new BadgeWidthConverter(WidthRequest), source: this));

            // Hide if no value
            SetBinding(VisualElement.IsVisibleProperty, new Binding("Text", BindingMode.OneWay,
                new BadgeVisibleValueConverter(), source: this));
        }

        public Badge(double width, double height, bool autoWidth)
        {
            HeightRequest = height;
            WidthRequest = width;

            box = new RoundedBoxView();
            box.CornerRadius = HeightRequest / 2;
            box.StrokeThickness = 2d;
            box.SetBinding(RoundedBoxView.StrokeProperty, new Binding("StrokeColor", source: this));
            box.SetBinding(VisualElement.BackgroundColorProperty, new Binding("BoxColor", source: this));
            Children.Add(box);

            label = new  MvvmAspire.Controls.Label();
            label.SetBinding(Xamarin.Forms.Label.TextProperty, new Binding("Text", source: this));
            label.SetBinding(Xamarin.Forms.Label.FontSizeProperty, new Binding("TextSize", source: this));
            label.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center;
            label.VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center;
            label.FontAttributes = FontAttributes.Bold;
            label.HorizontalOptions = LayoutOptions.Center;
            Children.Add(label);

            if (autoWidth)
            {
                // Auto-width
                SetBinding(VisualElement.WidthRequestProperty, new Binding("Text", BindingMode.OneWay,
                    new BadgeWidthConverter(WidthRequest), source: this));
            }

            // Hide if no value
            SetBinding(VisualElement.IsVisibleProperty, new Binding("Text", BindingMode.OneWay,
                new BadgeVisibleValueConverter(), source: this));
        }


        class BadgeVisibleValueConverter : IValueConverter
        {
            #region IValueConverter implementation

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var text = value as string;
                return !String.IsNullOrEmpty(text);
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            #endregion
        }

        class BadgeWidthConverter : IValueConverter
        {
            /// <summary>
            /// The width of the base.
            /// </summary>
            readonly double baseWidth;

            /// <summary>
            /// The width ratio.
            /// </summary>
            const double widthRatio = 0.33;

            public BadgeWidthConverter(double baseWidth)
            {
                this.baseWidth = baseWidth;
            }

            #region IValueConverter implementation

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var text = value as string;
                if ((text != null) && (text.Length > 1))
                {
                    // We won't measure text length exactly here!
                    // May be we should, but it's too tricky. So,
                    // we'll just approximate new badge width as
                    // linear function from text legth.

                    return baseWidth * (1 + widthRatio * (text.Length - 1));
                }
                return baseWidth;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            #endregion
        }
    }
}

