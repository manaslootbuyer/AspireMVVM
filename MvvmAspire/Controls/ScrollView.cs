using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class ScrollView : Xamarin.Forms.ScrollView
    {
        public static readonly BindableProperty BouncesProperty =
            BindableProperty.Create("Bounces", typeof(bool), typeof(ScrollView), true);

        public static readonly BindableProperty HasScrollbarProperty =
            BindableProperty.Create("HasScrollbar", typeof(bool), typeof(ScrollView), true);

        public static readonly BindableProperty MinZoomFactorProperty =
            BindableProperty.Create("MinZoomFactor", typeof(double), typeof(ScrollView), 1d);

        public static readonly BindableProperty MaxZoomFactorProperty =
            BindableProperty.Create("MaxZoomFactor", typeof(double), typeof(ScrollView), 1d);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MvvmAspire.Controls.ScrollView"/> bounces. Use for iOS.
        /// </summary>
        public bool Bounces
        {
            get { return (bool)GetValue(BouncesProperty); }
            set { SetValue(BouncesProperty, value); }
        }


        public bool HasScrollbar
        {
            get { return (bool)GetValue(HasScrollbarProperty); }
            set { SetValue(HasScrollbarProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value that indicates the minimum permitted run-time value of ZoomFactor.
        /// </summary>
        public double MinZoomFactor
        {
            get { return (double)GetValue(MinZoomFactorProperty); }
            set { SetValue(MinZoomFactorProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value that indicates the maximum permitted run-time value of ZoomFactor.
        /// </summary>
        public double MaxZoomFactor
        {
            get { return (double)GetValue(MaxZoomFactorProperty); }
            set { SetValue(MaxZoomFactorProperty, value); }
        }
    }
}
