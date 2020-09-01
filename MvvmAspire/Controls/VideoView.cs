using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class VideoView : View
    {
        public static readonly BindableProperty ShowControlProperty =
            BindableProperty.Create("ShowControl", typeof(bool), typeof(VideoView), false);

        public static readonly BindableProperty IsFromUrlProperty =
            BindableProperty.Create("IsFromUrl", typeof(bool), typeof(VideoView), false);

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("Source", typeof(string), typeof(VideoView), null);

        public static readonly BindableProperty PlayingProperty =
            BindableProperty.Create("Playing", typeof(bool), typeof(VideoView), false);

        public static readonly BindableProperty RepeatProperty =
            BindableProperty.Create("Repeat", typeof(bool), typeof(VideoView), false);

        /// <summary>
        /// for android only
        /// </summary>
        public static readonly BindableProperty LoaderTextProperty =
            BindableProperty.Create("LoaderText", typeof(string), typeof(VideoView), "");

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public string LoaderText
        {
            get { return (string)GetValue(LoaderTextProperty); }
            set { SetValue(LoaderTextProperty, value); }
        }

        public bool Playing
        {
            get { return (bool)GetValue(PlayingProperty); }
            set { SetValue(PlayingProperty, value); }
        }

        public bool Repeat
        {
            get { return (bool)GetValue(RepeatProperty); }
            set { SetValue(RepeatProperty, value); }
        }

        public bool IsFromUrl
        {
            get { return (bool)GetValue(IsFromUrlProperty); }
            set { SetValue(IsFromUrlProperty, value); }
        }

        public bool ShowControl
        {
            get { return (bool)GetValue(ShowControlProperty); }
            set { SetValue(ShowControlProperty, value); }
        }

    }
}