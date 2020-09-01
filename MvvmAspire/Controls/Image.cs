using System;
using Xamarin.Forms;
using System.Threading;
using System.Windows.Input;

namespace  MvvmAspire.Controls
{
    public class Image : Xamarin.Forms.Image
    {
        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<TouchEventArgs> TouchViewEvent = delegate { };

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(Image), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(Image), null);

        public static readonly BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(object), typeof(Image), null);

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof(double), typeof(Image), 0d);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(Image), Color.Default);

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create("FontSize", typeof(double), typeof(Image),  5d);

        public static readonly BindableProperty ImagePlaceholderProperty =
            BindableProperty.Create("ImagePlaceholder", typeof(ImageSource), typeof(Image), null);

        public static readonly BindableProperty LoadingProgressProperty =
            BindableProperty.Create("LoadingProgress", typeof(double), typeof(Image), 0d);

        public static readonly BindableProperty LoaderTypeProperty =
            BindableProperty.Create("LoaderType", typeof(ImageLoaderType), typeof(Image), ImageLoaderType.None, defaultBindingMode: BindingMode.TwoWay);

        public static readonly BindableProperty ShowActivityIndicatorWhileLoadingroperty =
            BindableProperty.Create("ShowActivityIndicatorWhileLoading", typeof(bool), typeof(Image), false);

        public static readonly BindableProperty IsImageLoadingProperty =
            BindableProperty.Create("IsImageLoading", typeof(bool), typeof(Image), false);

        public static readonly BindableProperty EnableTouchViewListenerProperty =
            BindableProperty.Create("EnableTouchViewListener", typeof(bool), typeof(Image), false);

        public static readonly BindableProperty UpdateImageTriggerProperty =
            BindableProperty.Create("UpdateImageTrigger", typeof(int), typeof(Image), 0);
        
        public static readonly BindableProperty AccessibilityTraitsProperty =
            BindableProperty.Create("AccessibilityTraits", typeof(string), typeof(Image), string.Empty);

        public double CornerRadius
        {
            get { return (double)base.GetValue(CornerRadiusProperty); }
            set { base.SetValue(CornerRadiusProperty, value); }
        }

        public ImageSource ImagePlaceholder
        {
            get { return (ImageSource)base.GetValue(ImagePlaceholderProperty); }
            set { base.SetValue(ImagePlaceholderProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)base.GetValue(CommandProperty); }
            set { base.SetValue(CommandProperty, value); }
        }

        //public Thickness Margin
        //{
        //    get { return (Thickness)base.GetValue(MarginProperty); }
        //    set { base.SetValue(MarginProperty, value); }
        //}

        //public bool IsClickable
        //{
        //    get { return (bool)base.GetValue(IsClickableProperty); }
        //    set { base.SetValue(IsClickableProperty, value); }
        //}

        public object CommandParameter
        {
            get { return (object)base.GetValue(CommandParameterProperty); }
            set { base.SetValue(CommandParameterProperty, value); }
        }

        public object Tag
        {
            get { return (object)base.GetValue(TagProperty); }
            set { base.SetValue(TagProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)base.GetValue(TextColorProperty); }
            set { base.SetValue(TextColorProperty, value); }
        }

        public double FontSize
        {
            get { return (double)base.GetValue(FontSizeProperty); }
            set { base.SetValue(FontSizeProperty, value); }
        }

        public double LoadingProgress
        {
            get { return (double)base.GetValue(LoadingProgressProperty); }
            set { base.SetValue(LoadingProgressProperty, value); }
        }

        public ImageLoaderType LoaderType
        {
            get { return (ImageLoaderType)base.GetValue(LoaderTypeProperty); }
            set { base.SetValue(LoaderTypeProperty, value); }
        }

        public int UpdateImageTrigger
        {
            get { return (int)base.GetValue(UpdateImageTriggerProperty); }
            set { base.SetValue(UpdateImageTriggerProperty, value); }
        }

        public string AccessibilityTraits
        {
            get { return (string)base.GetValue(AccessibilityTraitsProperty); }
            set { base.SetValue(AccessibilityTraitsProperty, value); }
        }

        public bool ShowActivityIndicatorWhileLoading
        {
            get { return (bool)base.GetValue(ShowActivityIndicatorWhileLoadingroperty); }
            set { base.SetValue(ShowActivityIndicatorWhileLoadingroperty, value); }
        }

        public bool EnableTouchViewListener
        {
            get { return (bool)base.GetValue(EnableTouchViewListenerProperty); }
            set { base.SetValue(EnableTouchViewListenerProperty, value); }
        }

        public bool IsImageLoading
        {
            get { return (bool)base.GetValue(IsImageLoadingProperty); }
            set { base.SetValue(IsImageLoadingProperty, value); }
        }

        public void OnTouchEvent(TouchEventArgs args)
        {
            if (TouchViewEvent != null)
                TouchViewEvent.Invoke(this, args);

        }
    }

    public class TouchEventArgs : EventArgs
	{
		public double x;
		public double y;
		public TouchState state;

		public TouchEventArgs (double x, double y, TouchState touchState) {
			this.x = x;
			this.y = y;
			this.state = touchState;
		}

	}

	public enum TouchState { 
		BEGAN, MOVED, ENDED
	}
}

