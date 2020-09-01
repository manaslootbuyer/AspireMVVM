using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using MvvmAspire.Controls;
using MvvmAspire.Droid.Controls;
using System.ComponentModel;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(FastCell), typeof(FastCellRenderer))]
namespace MvvmAspire.Droid.Controls
{
    internal sealed class NativeCell : ViewGroup
    {

        public NativeCell(Android.Content.Context context, FastCell fastCell)
            : base(context)
        {
            FastCell = fastCell;
            fastCell.PrepareCell();
            //var renderer = RendererFactory.GetRenderer(fastCell.View);
            //this.AddView(renderer.ViewGroup);

            var renderer = Xamarin.Forms.Platform.Android.Platform.CreateRendererWithContext(fastCell.View,context);
            this.AddView(renderer.View);
        }

        public FastCell FastCell
        {
            get;
            set;
        }

        Size _lastSize;

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            if (changed)
            {
                //TODO
            }
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            //TODO update sizes of the xamarin view
            var newSize = new Size(w, h);
            if (_lastSize.Equals(Size.Zero) || !_lastSize.Equals(newSize))
            {

                //				var layout = FastCell.Content;
                var layout = FastCell.View as Layout<Xamarin.Forms.View>;
                if (layout != null)
                {
                    layout.Layout(new Rectangle(0, 0, w, h));
                    layout.ForceLayout();
                    FixChildLayouts(layout);
                }
                _lastSize = newSize;
            }

            //TODO set the frame size
        }

        void FixChildLayouts(Layout<Xamarin.Forms.View> layout)
        {
            foreach (var child in layout.Children)
            {
                if (child is StackLayout)
                {
                    ((StackLayout)child).ForceLayout();
                    FixChildLayouts(child as Layout<Xamarin.Forms.View>);
                }
                if (child is Xamarin.Forms.AbsoluteLayout)
                {
                    ((Xamarin.Forms.AbsoluteLayout)child).ForceLayout();
                    FixChildLayouts(child as Layout<Xamarin.Forms.View>);
                }
            }
        }
    }





    public class FastCellRenderer : ViewCellRenderer
    {
        private Drawable _unselectedBackground;
        private bool _selected;
        private Android.Views.View _cellCore;
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {

            var cellCache = FastCellCache.Instance.GetCellCache(parent);
            var fastCell = item as FastCell;

            _cellCore  = convertView;
            _selected = false;

            if (_cellCore != null && cellCache.IsCached(_cellCore))
            {
                cellCache.RecycleCell(_cellCore, fastCell);
                _unselectedBackground = _cellCore.Background;
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
                _cellCore = base.GetCellCore(newCell, convertView, parent, context);
                cellCache.CacheCell(newCell, _cellCore);
                _unselectedBackground = _cellCore.Background;
            }


            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
            if (e.PropertyName == "IsSelected")
            {
                _selected = !_selected;

                if (_selected)
                {
                    var extendedViewCell = sender as FastCell;

                    if(extendedViewCell.SelectionMode)
                    _cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
                    else{
                        _cellCore.SetBackgroundColor(Xamarin.Forms.Color.Transparent.ToAndroid());
                    }
                }
                else
                {
                    _cellCore.SetBackground(_unselectedBackground);
                }
            }
        }


    }
}

