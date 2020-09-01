﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Collections.Generic;
using MvvmAspire.Controls;

[assembly: ExportRenderer(typeof(FastCell), typeof(FastCellRenderer))]
namespace MvvmAspire.Controls
{
    public class NativeCell : UITableViewCell
    {

        UIView _view;
        FastCell _fastCell;

        public override string ToString()
        {
            return string.Format("[NativeCell: FC.BC={0}  FC.OBC={1}]", _fastCell.BindingContext, _fastCell.OriginalBindingContext);
        }

        public NativeCell(NSString cellId, FastCell fastCell) : base(UITableViewCellStyle.Default, cellId)
        {
            _fastCell = fastCell;
            _fastCell.PrepareCell();
            //			_fastCell.OriginalBindingContext = _fastCell.BindingContext;

            var renderer = Xamarin.Forms.Platform.iOS.Platform.CreateRenderer(fastCell.View);
            _view = renderer.NativeView;
            ContentView.AddSubview(_view);
        }

        public void RecycleCell(FastCell newCell)
        {
            if (newCell == _fastCell)
            {
                _fastCell.BindingContext = _fastCell.OriginalBindingContext;
            }
            else
            {
                _fastCell.BindingContext = newCell.BindingContext;
            }
            _fastCell.BindingContext = newCell.BindingContext;
        }

        CGSize _lastSize;

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            //TODO update sizes of the xamarin view
            if (_lastSize.Equals(CGSize.Empty) || !_lastSize.Equals(Frame.Size))
            {

                var layout = _fastCell.View as Layout<View>;
                if (layout != null)
                {
                    layout.Layout(Frame.ToRectangle());
                    layout.ForceLayout();
                    FixChildLayouts(layout);
                }
                _lastSize = Frame.Size;
            }

            _view.Frame = ContentView.Bounds;
        }

        void FixChildLayouts(Layout<View> layout)
        {
            foreach (var child in layout.Children)
            {
                if (child is StackLayout)
                {
                    ((StackLayout)child).ForceLayout();
                    FixChildLayouts(child as Layout<View>);
                }
                if (child is AbsoluteLayout)
                {
                    ((AbsoluteLayout)child).ForceLayout();
                    FixChildLayouts(child as Layout<View>);
                }
            }
        }
    }



    public class FastCellRenderer : Xamarin.Forms.Platform.iOS.ViewCellRenderer
    {
        public FastCellRenderer()
        {
        }

        NSString cellId;

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            cellId = cellId ?? new NSString(item.GetType().FullName);
            var cellCache = FastCellCache.Instance.GetCellCache(tv);
            var fastCell = item as FastCell;
            var nativeCell = reusableCell as NativeCell;
            var view = item as FastCell;
          

            if (reusableCell != null && cellCache.IsCached(nativeCell))
            {
                cellCache.RecycleCell(nativeCell, fastCell);

                if(fastCell.SelectionMode){
                    nativeCell.SelectedBackgroundView = new UIView
                    {
                        BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
                    };
                }else{
                    //nativeCell.SelectedBackgroundView = new UIView
                    //{
                    //    BackgroundColor = UIColor.Clear,
                    //};
                    nativeCell.SelectionStyle = UITableViewCellSelectionStyle.None;
                }
            
            }
            else
            {
                var newCell = (FastCell)Activator.CreateInstance(item.GetType());
                newCell.BindingContext = item.BindingContext;
                newCell.Parent = item.Parent;

                if (!newCell.IsInitialized)
                {
                    newCell.PrepareCell();
                }
                nativeCell = new NativeCell(cellId, newCell);
                cellCache.CacheCell(newCell, nativeCell);

                if (fastCell.SelectionMode)
                {
                    nativeCell.SelectedBackgroundView = new UIView
                    {
                        BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
                    };
                }
                else
                {
                    nativeCell.SelectionStyle = UITableViewCellSelectionStyle.None;
                }
            }

            var parentListview = fastCell.Parent as MvvmAspire.Controls.ListView;
            if (parentListview != null)
            {
                parentListview.Raise("ItemAppearing", new ItemVisibilityEventArgs(item.BindingContext));
            }

            return nativeCell;
        }

    }
}