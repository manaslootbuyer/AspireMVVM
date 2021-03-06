﻿using System.Drawing;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MvvmAspire.Controls
{
    [Register("CustomRadioButtonView")]
    public class CustomRadioButtonView : UIButton
    {
        public CustomRadioButtonView()
        {
            Initialize();
        }

        public CustomRadioButtonView(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }


        public bool Checked
        {
            set { this.Selected = value; }
            get { return this.Selected; }
        }

        public string Text
        {
            set { this.SetTitle(value, UIControlState.Normal); }

        }

        void Initialize()
        {
            this.AdjustEdgeInsets();
            this.ApplyStyle();
            this.TouchUpInside += (sender, args) => this.Selected = !this.Selected;
        }

        void AdjustEdgeInsets()
        {
            const float inset = 8f;
            this.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            this.ImageEdgeInsets = new UIEdgeInsets(0f, inset, 0f, 0f);
            this.TitleEdgeInsets = new UIEdgeInsets(0f, inset * 2, 0f, 0f);
        }

        void ApplyStyle()
        {
            this.SetImage(UIImage.FromBundle("checked.png"), UIControlState.Selected);
            this.SetImage(UIImage.FromBundle("unchecked.png"), UIControlState.Normal);
        }
    }
}