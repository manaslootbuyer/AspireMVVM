using System;
using  MvvmAspire.Controls;
using Xamarin.Forms;

namespace  MvvmAspire.Controls
{
    public class ExpandableEditor :  MvvmAspire.Controls.Editor
    {
        public ExpandableEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~ExpandableEditor()
        {
            TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidateMeasure();
        }
    }
}
