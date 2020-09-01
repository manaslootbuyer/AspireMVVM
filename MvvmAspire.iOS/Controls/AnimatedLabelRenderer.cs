using MvvmAspire.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MvvmAspire.Controls.AnimatedLabel), typeof(AnimatedLabelRenderer))]
namespace MvvmAspire.Controls
{
    public class AnimatedLabelRenderer : LabelControlRenderer
    {
        public override void TouchesBegan(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (base.Element != null)
            {
                UIView.Animate(0.25,
                    animation: async () =>
                    {
                        await base.Element.ScaleTo(0.9, 100);
                    },
                    completion: () => {
                        base.TouchesBegan(touches, evt);
                    }
                );


            }
            else
            {
                base.TouchesBegan(touches, evt);
            }
        }

        public override void TouchesEnded(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (base.Element != null)
            {
                UIView.Animate(0.25,
                    animation: async () =>
                    {
                        await base.Element.ScaleTo(1, 100);
                    },
                    completion: () => {
                        base.TouchesEnded(touches, evt);
                    }
                );
            }
            else
            {
                base.TouchesEnded(touches, evt);
            }
        }

        public override void TouchesCancelled(Foundation.NSSet touches, UIKit.UIEvent evt)
        {
            if (base.Element != null)
            {

                UIView.Animate(0.25,
                    animation: async () =>
                    {
                        await base.Element.ScaleTo(1, 100);
                    },
                    completion: () => {
                        base.TouchesCancelled(touches, evt);
                    }
                );
            }
            else
            {
                base.TouchesCancelled(touches, evt);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
        }
    }
}
