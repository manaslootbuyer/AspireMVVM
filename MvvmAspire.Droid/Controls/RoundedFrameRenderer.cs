using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;
using System.Threading.Tasks;
using Android.Text;
using Android.Text.Style;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Graphics.Drawables.Shapes;
using Android.Support.V4.Graphics.Drawable;

namespace   MvvmAspire.Controls
{
    public class RoundFrameRenderer : ViewRenderer
    {
        protected RoundedFrame Base { get { return (RoundedFrame)Element; } }


        public RoundFrameRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null) return;

            var view = new Android.Widget.RelativeLayout(this.Context);


            if (Base.BackgroundImage != null)
            {
                var imageView = new ImageView(this.Context);
                imageView.SetScaleType(ImageView.ScaleType.FitXy);
                var cornerRad = Base.CornerRadius.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                var res = this.Context.Resources;
                var resourceId = UIHelper.GetDrawableResource(Base.BackgroundImage);

                Bitmap src = BitmapFactory.DecodeResource(res, resourceId);
                var dr = RoundedBitmapDrawableFactory.Create(res, src);
                dr.CornerRadius = float.Parse(cornerRad[0]);
                imageView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                imageView.SetBackground(dr);
                imageView.SetImageBitmap(src);

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    imageView.ClipToOutline = true;
                }


                view.AddView(imageView);
            }

            this.SetBackgroundColor(Xamarin.Forms.Color.Default.ToAndroid());
            SetNativeControl(view);

            if (!string.IsNullOrWhiteSpace(Base.GradientColor))
                view.Background = GradientConverter(Base.GradientColor);
            else
            {
                CreateShapeDrawable();
            }

            Element.PropertyChanged += (s, ev) =>
            {
                if (Element == null) return;
                switch (ev.PropertyName)
                {
                    case "GradientColor": view.Background = GradientConverter(Base.GradientColor); break;
                    case "HasBorder": break;
                }
            };
        }

        void CreateShapeDrawable()
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);

            float[] cornerRadii = new float[] { 10, 10, 10, 10, 10, 10, 10, 10 };

            if (Base.CornerRadius != "-1")
            {
                var cornerRad = Base.CornerRadius.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                cornerRadii = new float[] { BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[0])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[1])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[2])),
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[3])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[4])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[5])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[6])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[7])) };
            }



            shape.SetCornerRadii(cornerRadii);

            var element = Element as RoundedFrame;
            if (element.BackgroundColor != Xamarin.Forms.Color.Default)
                shape.SetColor(element.BackgroundColor.ToAndroid());

            if (Base.HasBorder)
            {
                shape.SetStroke(1, Base.BorderColor.ToAndroid());
            }

            Control.Background = shape;
        }

        protected ShapeDrawable GradientConverter(String Gradient)
        {
            float[] array = new float[] { 250, 250, 250, 250, 250, 250, 250, 250 };

            if (Base.CornerRadius != "-1")
            {
                var cornerRad = Base.CornerRadius.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                array = new float[] { BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[0])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[1])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[2])),
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[3])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[4])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[5])), BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[6])), 
                BaseUIHelper.ConvertDPToPixels(float.Parse(cornerRad[7])) };
            }

            ShapeDrawable sf = new ShapeDrawable(new RoundRectShape(array, null, null));
            // sf.SetIntrinsicHeight(100);
            //sf.SetIntrinsicWidth(200);

            sf.SetShaderFactory(new GradientShader(Gradient));

            if (Base.HasBorder)
            {
                sf.Paint.StrokeWidth = 1;
                sf.Paint.Color = Base.BorderColor.ToAndroid();
            }


            return sf;
        }

        public class GradientShader : ShapeDrawable.ShaderFactory
        {
            string[] gradientColors;
            public GradientShader(String Gradient)
            {
                gradientColors = Gradient.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            }
            public override Shader Resize(int width, int height)
            {
                LinearGradient gradient = null;
                if (gradientColors.Count() > 0)
                {
                    int[] colorList = new int[gradientColors.Count()];
                    float[] offsetColor = new float[gradientColors.Count()];
                    for (int i = 0; i < gradientColors.Count(); i++)
                    {

                        var gradientColorOffset = gradientColors[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        colorList[i] = Android.Graphics.Color.ParseColor(gradientColorOffset[0]);
                        int offsetInt = Int32.Parse(gradientColorOffset[1].Replace("%", ""));
                        float offsetFloat = offsetInt / 100f;
                        offsetColor[i] = offsetFloat;
                    }



                    gradient = new LinearGradient(0, 0, 0, height,
                      colorList,
                       offsetColor,
                       Shader.TileMode.Clamp);

                }
                return gradient;
            }
        }

    }

}