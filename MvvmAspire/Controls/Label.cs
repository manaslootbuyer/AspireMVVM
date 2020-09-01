using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class Label : Xamarin.Forms.Label
    {
        public static BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(object), typeof(Label), null);

        public static BindableProperty AutoFitProperty =
            BindableProperty.Create("AutoFit", typeof(bool), typeof(Label), false);

        public static BindableProperty IsSelectableProperty =
         BindableProperty.Create("IsSelectable", typeof(bool), typeof(Label), false);

        public static BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(System.Windows.Input.ICommand), typeof(Label), null);

        public static BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(Label), null);

        public static BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(Label), Color.Default);

        ////public static BindableProperty FontStyleProperty =
            //BindableProperty.Create("FontStyle", typeof(FontStyle), typeof(Label), FontStyle.Regular);

        public static BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(Label), null);

        public static BindableProperty PlaceholderColorProperty =
            BindableProperty.Create("PlaceholderColor", typeof(Color), typeof(Label), Color.Default);

        //public static BindableProperty MaxCharactersProperty = BindableProperty.Create <Label, int?>(l => l.MaxCharacters, null);

        public static BindableProperty MaxLinesProperty =
            BindableProperty.Create("MaxLines", typeof(int), typeof(Label), 0);

        public static BindableProperty MaxWidthProperty =
            BindableProperty.Create("MaxWidth", typeof(double?), typeof(Label), null);

        public static BindableProperty LineSpacingProperty =
            BindableProperty.Create("LineSpacing", typeof(float), typeof(Label), 0.7f);

        public static BindableProperty TextStyleProperty =
            BindableProperty.Create("TextStyle", typeof(TextStyling), typeof(Label), TextStyling.None);

        public static BindableProperty RefitTextEnabledProperty =
            BindableProperty.Create("RefitTextEnabled", typeof(bool), typeof(Label), false);

        public static BindableProperty RequiredProperty =
            BindableProperty.Create("Required", typeof(bool), typeof(Label), false);

        public static BindableProperty InputTypeProperty =
            BindableProperty.Create("InputType", typeof(TextInputType), typeof(Label), TextInputType.None);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(Label), new Thickness(0));

        public static readonly BindableProperty AccessibilityTraitsProperty =
            BindableProperty.Create("AccessibilityTraits", typeof(string), typeof(Label), string.Empty);

        public static BindableProperty AccesibilitySetFocusProperty =
            BindableProperty.Create("AccesibilitySetFocus", typeof(bool), typeof(Label), false, BindingMode.TwoWay);

        public bool Required
        {
            get { return (bool)GetValue(RequiredProperty); }
            set { SetValue(RequiredProperty, value); }
        }

        public bool IsSelectable
        {
            get { return (bool)GetValue(IsSelectableProperty); }
            set { SetValue(IsSelectableProperty, value); }
        }


        public bool RefitTextEnabled
        {
            get { return (bool)GetValue(RefitTextEnabledProperty); }
            set { SetValue(RefitTextEnabledProperty, value); }
        }

        public TextInputType InputType
        {
            get { return (TextInputType)GetValue(InputTypeProperty); }
            set { SetValue(InputTypeProperty, value); }
        }

        /// <summary>
        /// Note: This is not implemented in iOS. iOS Label does not have padding property or alike.
        /// </summary>
        /// <value>The padding.</value>
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the font style for the text using the mapped fonts in IFontService.
        /// </summary>
        //public FontStyle FontStyle
        //{
        //    get { return (FontStyle)GetValue(FontStyleProperty); }
        //    set { SetValue(FontStyleProperty, value); }
        //}

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public System.Windows.Input.ICommand Command
        {
            get { return (System.Windows.Input.ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object Tag
        {
            get { return (bool)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public bool AutoFit
        {
            get { return (bool)GetValue(AutoFitProperty); }
            set { SetValue(AutoFitProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    
        public bool AccesibilitySetFocus
        {
            get { return (bool)GetValue(AccesibilitySetFocusProperty); }
            set { SetValue(AccesibilitySetFocusProperty, value); }
        }


        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }

        public string AccessibilityTraits
        {
            get { return (string)base.GetValue(AccessibilityTraitsProperty); }
            set { base.SetValue(AccessibilityTraitsProperty, value); }
        }

        //public int? MaxCharacters
        //{
        //    get { return (int?)GetValue(MaxCharactersProperty); }
        //    set { SetValue(MaxCharactersProperty, value); }
        //}

        public double? MaxWidth
        {
            get { return (double?)GetValue(MaxWidthProperty); }
            set { SetValue(MaxWidthProperty, value); }
        }

        /// <summary>
        /// works with android only
        /// </summary>
        public float LineSpacing
        {
            get { return (float)GetValue(LineSpacingProperty); }
            set { SetValue(LineSpacingProperty, value); }

        }
        public TextStyling TextStyle
        {
            get { return (TextStyling)GetValue(TextStyleProperty); }
            set { SetValue(TextStyleProperty, value); }
        }

        public Label()
        {
            //SetFontFamily();
        }

        //protected override void OnPropertyChanged(string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);

        //    if (propertyName == "FontStyle")
        //        SetFontFamily();
        //}

        //protected void SetFontFamily()
        //{
        //    var fontService = Resolver.Get<IFontService>();
        //    if (fontService == null) return;
        //    this.FontFamily = fontService.GetFontName(this.FontStyle);
        //}
    }
}
