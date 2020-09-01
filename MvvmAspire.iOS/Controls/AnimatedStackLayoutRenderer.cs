using MvvmAspire.Controls;
using CoreGraphics;
using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Threading;

[assembly: ExportRenderer(typeof(MvvmAspire.Controls.AnimatedStackLayout), typeof(AnimatedStackLayoutRenderer))]
namespace MvvmAspire.Controls
{
    public class AnimatedStackLayoutRenderer : ViewRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                
            }
        }

        public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
        {
            if(base.Element != null)
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

        public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
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

        public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
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
    }
}
