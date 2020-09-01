using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using   MvvmAspire.Controls;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Views;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.AnimatedStackLayout), typeof(AnimatedStackLayoutRenderer))]
namespace   MvvmAspire.Controls
{
    public class AnimatedStackLayoutRenderer : ViewRenderer
    {
        private static   MvvmAspire.Controls.AnimatedStackLayout _animatedStackLayout;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            var animatedStackLayout= (  MvvmAspire.Controls.AnimatedStackLayout)Element;
            _animatedStackLayout = animatedStackLayout;

            if(Control != null)
                Control.SetOnTouchListener(new MyTouchListener());
        }


        public class MyTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
        {
            private float initialY, finalY;

            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                if (e.Action == MotionEventActions.Down)
                {
                    _animatedStackLayout.ScaleTo(0.9, 100);


                }
                if (e.Action == MotionEventActions.Up)
                {
                    _animatedStackLayout.ScaleTo(1, 100);
                    var tap = _animatedStackLayout?.GestureRecognizers[0] as TapGestureRecognizer;
                    var command = tap?.Command;

                    if (command != null)
                        command.Execute(tap.CommandParameter);
                }
                if (e.Action == MotionEventActions.Cancel)
                {
                    _animatedStackLayout.ScaleTo(1, 100);
                }

                return true;
            }
        }

        public AnimatedStackLayoutRenderer(Context context) : base(context)
        {
        }
    }
}
