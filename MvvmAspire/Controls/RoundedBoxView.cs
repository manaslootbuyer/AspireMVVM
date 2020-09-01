using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class RoundedBoxView : Xamarin.Forms.BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedBoxView), 60d);

        public static readonly BindableProperty StrokeProperty =
            BindableProperty.Create("Stroke", typeof(Color), typeof(RoundedBoxView), Color.Transparent);

        public static readonly BindableProperty StrokeThicknessProperty =
            BindableProperty.Create("StrokeThickness", typeof(double), typeof(RoundedBoxView), 0d);

        public double CornerRadius
        {
            get { return (double)base.GetValue(CornerRadiusProperty); }
            set { base.SetValue(CornerRadiusProperty, value); }
        }

        public Color Stroke
        {
            get { return (Color)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }
    }
}
