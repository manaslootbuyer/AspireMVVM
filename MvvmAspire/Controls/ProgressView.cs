using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class ProgressView : Label
    {
        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create("Minimum", typeof(int), typeof(ProgressView), 0);

        public static readonly BindableProperty BackgroundImageProperty =
            BindableProperty.Create("BackgroundImage", typeof(FileImageSource), typeof(ProgressView), null);

        public static readonly BindableProperty ThumbImageProperty =
            BindableProperty.Create("ThumbImage", typeof(FileImageSource), typeof(ProgressView), null);

        public static readonly BindableProperty PaddingLeftProperty =
            BindableProperty.Create("PaddingLeft", typeof(double), typeof(ProgressView), 0d);

        public static readonly BindableProperty PaddingRightProperty =
            BindableProperty.Create("PaddingRight", typeof(double), typeof(ProgressView), 0d);

        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create("Progress", typeof(double), typeof(ProgressView), 0d, BindingMode.TwoWay);

        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create("Maximum", typeof(double), typeof(ProgressView), 0d);

        public static readonly BindableProperty ParentWidthProperty =
            BindableProperty.Create("ParentWidth", typeof(double), typeof(ProgressView), 0d);

        public static readonly BindableProperty TouchableProperty =
            BindableProperty.Create("Touchable", typeof(bool), typeof(ProgressView), true);

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public FileImageSource BackgroundImage
        {
            get { return (FileImageSource)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public FileImageSource ThumbImage
        {
            get { return (FileImageSource)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }

        public double PaddingLeft
        {
            get { return (double)GetValue(PaddingLeftProperty); }
            set { SetValue(PaddingLeftProperty, value); }
        }

        public double PaddingRight
        {
            get { return (double)GetValue(PaddingRightProperty); }
            set { SetValue(PaddingRightProperty, value); }
        }

        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public double ParentWidth
        {
            get { return (double)GetValue(ParentWidthProperty); }
            set { SetValue(ParentWidthProperty, value); }
        }

        public bool Touchable
        {
            get { return (bool)GetValue(TouchableProperty); }
            set { SetValue(TouchableProperty, value); }
        }

        //Swipe events

        public event EventHandler SwipeLeft;
        public event EventHandler SwipeRight;

        public void OnSwipeLeft()
        {
            EventHandler handler = SwipeLeft;
            if (handler != null)
                SwipeLeft(this, null);
        }

        public void OnSwipeRight()
        {
            EventHandler handler = SwipeRight;
            if (handler != null)
                SwipeRight(this, null);
        }

        public double FinalX
        {
            get;
            set;
        }

        public double InitialX
        {
            get;
            set;
        }
    }
}
