using System;
using System.ComponentModel;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Method;
using Android.Text.Style;
using Android.Widget;
using Java.Lang;
using MvvmAspire.Controls;
using Org.Xml.Sax;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace MvvmAspire.Controls
{
    [Preserve(AllMembers = true)]
    public class HtmlLabelRenderer : LabelRenderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public HtmlLabelRenderer(Android.Content.Context context) : base(context) { }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Initialize() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (Control == null) return;

            UpdateText();
            UpdateMaxLines();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == HtmlLabel.MaxLinesProperty.PropertyName)
                UpdateMaxLines();
            else if (e.PropertyName == Label.TextProperty.PropertyName ||
                     e.PropertyName == Label.FontAttributesProperty.PropertyName ||
                     e.PropertyName == Label.FontFamilyProperty.PropertyName ||
                     e.PropertyName == Label.FontSizeProperty.PropertyName ||
                     e.PropertyName == Label.HorizontalTextAlignmentProperty.PropertyName ||
                     e.PropertyName == Label.TextColorProperty.PropertyName)
                UpdateText();
        }

        private void UpdateMaxLines()
        {
            var maxLines = HtmlLabel.GetMaxLines(Element);
            if (maxLines == default(int)) return;
            Control.SetMaxLines(maxLines);
        }

        private void UpdateText()
        {
            if (Control == null || Element == null) return;
            if (string.IsNullOrEmpty(Control.Text)) return;

            // Gets the complete HTML string
            var customHtml = new LabelRendererHelper(Element, Control.Text).ToString();
            // Android's TextView doesn't handle <ul>s, <ol>s and <li>s 
            // so it replaces them with <ulc>, <olc> and <lic> respectively.
            // Those tags will be handles by a custom TagHandler
            customHtml = customHtml.Replace("ul>", "ulc>").Replace("ol>", "olc>").Replace("li>", "lic>");

            Control.SetIncludeFontPadding(false);

            SetTextViewHtml(Control, customHtml);
        }

        private void SetTextViewHtml(TextView text, string html)
        {
            // Tells the TextView that the content is HTML and adds a custom TagHandler
            var sequence = Build.VERSION.SdkInt >= BuildVersionCodes.N ?
                Html.FromHtml(html, FromHtmlOptions.ModeLegacy, null, new ListTagHandler()) :
#pragma warning disable 618
                Html.FromHtml(html, null, new ListTagHandler());
#pragma warning restore 618

            // Makes clickable links
            text.MovementMethod = LinkMovementMethod.Instance;
            var strBuilder = new SpannableStringBuilder(sequence);
            var urls = strBuilder.GetSpans(0, sequence.Length(), Class.FromType(typeof(URLSpan)));
            foreach (var span in urls)
                MakeLinkClickable(strBuilder, (URLSpan)span);

            // Android adds an unnecessary "\n" that must be removed
            var value = RemoveLastChar(strBuilder);

            // Finally sets the value of the TextView 
            text.SetText(value, TextView.BufferType.Spannable);
        }

        private void MakeLinkClickable(ISpannable strBuilder, URLSpan span)
        {
            var start = strBuilder.GetSpanStart(span);
            var end = strBuilder.GetSpanEnd(span);
            var flags = strBuilder.GetSpanFlags(span);
            var clickable = new MyClickableSpan((HtmlLabel)Element, span);
            strBuilder.SetSpan(clickable, start, end, flags);
            strBuilder.RemoveSpan(span);
        }

        private class MyClickableSpan : ClickableSpan
        {
            private readonly HtmlLabel _label;
            private readonly URLSpan _span;

            public MyClickableSpan(HtmlLabel label, URLSpan span)
            {
                _label = label;
                _span = span;
            }

            public override void OnClick(global::Android.Views.View widget)
            {
                var args = new WebNavigatingEventArgs(WebNavigationEvent.NewPage, new UrlWebViewSource { Url = _span.URL }, _span.URL);
                _label.SendNavigating(args);

                if (args.Cancel)
                    return;

                Device.OpenUri(new Uri(_span.URL));
                _label.SendNavigated(args);
            }
        }

        private static ISpanned RemoveLastChar(ICharSequence text)
        {
            var builder = new SpannableStringBuilder(text);
            if (text.Length() != 0)
                builder.Delete(text.Length() - 1, text.Length());
            return builder;
        }
    }

    // TagHandler that handles lists (ul, ol)
    internal class ListTagHandler : Java.Lang.Object, Html.ITagHandler
    {
         public void HandleTag(bool opening, string tag, IEditable output, IXMLReader xmlReader)
        {

            Console.WriteLine("Tag:" + tag);
            if (tag.Equals("ulc") && !opening) output.Append("\n");
            else if (tag.Equals("lic") && opening) output.Append("\n\t•\t");
        }
    }
}
