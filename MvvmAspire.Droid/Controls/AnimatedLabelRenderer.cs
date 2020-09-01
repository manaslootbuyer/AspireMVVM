using MvvmAspire.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Views;

[assembly: ExportRenderer(typeof(  MvvmAspire.Controls.AnimatedLabel), typeof(AnimatedLabelRenderer))]
namespace   MvvmAspire.Controls
{
    public class AnimatedLabelRenderer : LabelControlRenderer
    {
        

        public AnimatedLabelRenderer(Context context) : base(context)
        {
        }

        public class MyTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
        {
            private float initialY, finalY;
            private    MvvmAspire.Controls.AnimatedLabel _animatedLabel;

            public MyTouchListener(  MvvmAspire.Controls.AnimatedLabel animatedLabel) 
            {
                _animatedLabel = animatedLabel;
            }
            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                if (e.Action == MotionEventActions.Down)
                {
                    _animatedLabel.ScaleTo(0.9, 100);

          
                }
                if (e.Action == MotionEventActions.Up)
                {
                    _animatedLabel.ScaleTo(1, 100);
                    try{
                        var tap = _animatedLabel?.GestureRecognizers[0] as TapGestureRecognizer;
                        var command = tap?.Command;

                        if (command != null)
                            command.Execute(tap.CommandParameter);
                    }catch(Exception){
                        
                    }

                   
                }
                if (e.Action == MotionEventActions.Cancel)
                {
                    _animatedLabel.ScaleTo(1, 100);
                }

                return true;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;

            var animatedLabelControl = (  MvvmAspire.Controls.AnimatedLabel)Element;

            var thisButton = Control as Android.Widget.TextView;


            if(thisButton != null)
            {
                Control.SetOnTouchListener(new MyTouchListener(animatedLabelControl));
            }

        }
    }
}
