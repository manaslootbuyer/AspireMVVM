using System;
using Xamarin.Forms.Platform.iOS;

namespace MvvmAspire.Controls
{
	public class HorizontalScrollRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			PanGestureRecognizer.DelaysTouchesBegan = DelaysContentTouches;
		}
	}
}

