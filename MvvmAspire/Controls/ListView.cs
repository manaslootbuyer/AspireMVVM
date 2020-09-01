using  MvvmAspire.Collections;
using  MvvmAspire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections;
using System.Reflection;
using  MvvmAspire;

namespace  MvvmAspire.Controls
{
    public class ListView : Xamarin.Forms.ListView
    {
        public static BindableProperty SeparatorBackgroundProperty =
            BindableProperty.Create("SeparatorBackground", typeof(FileImageSource), typeof(ListView), null);

        //public static BindableProperty SeparatorColorProperty =
        //    BindableProperty.Create <ListView, Color>(p => p.SeparatorColor, Color.Transparent);

        public static BindableProperty SeparatorHeightProperty =
            BindableProperty.Create("SeparatorHeight", typeof(double), typeof(ListView), 1d);

        public static BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(ListView), new Thickness(0));

        public static BindableProperty TransparentSeparatorProperty =
            BindableProperty.Create("TransparentSeparator", typeof(FileImageSource), typeof(ListView), null);

        public static BindableProperty DataTemplateTypeProperty =
            BindableProperty.Create("DataTemplateType", typeof(Type), typeof(ListView), null);

        public static BindableProperty EmptyTextProperty =
            BindableProperty.Create("EmptyText", typeof(string), typeof(ListView), "");

        public static BindableProperty ScrollToTopChangeProperty =
            BindableProperty.Create("ScrollToTopChange", typeof(bool), typeof(ListView), false, BindingMode.TwoWay);

        //public static BindableProperty EmptyTextFontStyleProperty =
            //BindableProperty.Create("EmptyTextFontStyle", typeof(FontStyle), typeof(ListView), FontStyle.Italic);

        public static BindableProperty EmptyTextFontSizeProperty =
            BindableProperty.Create("EmptyTextFontSize", typeof(double), typeof(ListView),  17d);

        public static BindableProperty EmptyTextColorProperty =
            BindableProperty.Create("EmptyTextColor", typeof(Color), typeof(ListView), Color.Default);

        public static BindableProperty EmptyTextBackgroundProperty =
            BindableProperty.Create("EmptyTextBackground", typeof(FileImageSource), typeof(ListView), null);

        public static BindableProperty SelectorProperty =
            BindableProperty.Create("Selector", typeof(ListViewSelector), typeof(ListView), ListViewSelector.Default);

        public static BindableProperty ClickableProperty =
            BindableProperty.Create("Clickable", typeof(bool), typeof(ListView), true);

        public static BindableProperty DismissKeyboardOnDragProperty =
            BindableProperty.Create("DismissKeyboardOnDrag", typeof(bool), typeof(ListView), true);

        public static BindableProperty UseCustomRendererProperty =
            BindableProperty.Create("UseCustomRenderer", typeof(bool), typeof(ListView), true);

        public static BindableProperty SelectOnLongClickProperty =
            BindableProperty.Create("SelectItemOnLongClick", typeof(bool), typeof(ListView), false);

        public static BindableProperty SwipeEnabledProperty =
            BindableProperty.Create("SwipeEnabled", typeof(bool), typeof(ListView), false);

        public static BindableProperty ScrollToIndexProperty =
            BindableProperty.Create("ScrollToIndex", typeof(int), typeof(ListView), -1);

        public static BindableProperty LastVisiblePositionProperty =
            BindableProperty.Create("LastVisiblePosition", typeof(int), typeof(ListView), -1);

        public static BindableProperty LoadMoreOffsetProperty =
            BindableProperty.Create("LoadMoreOffset", typeof(int), typeof(ListView), 2);

        public static BindableProperty ItemContainerStyleProperty =
            BindableProperty.Create("ItemContainerStyle", typeof(string), typeof(ListView), null);

        public static BindableProperty TagProperty =
            BindableProperty.Create("Tag", typeof(string), typeof(ListView), "");

        /// <summary>
        /// Add reverse collection property if enabled. E.G. Messaging ListView
        /// </summary>
        public static BindableProperty ReverseCollectionEnabledProperty =
            BindableProperty.Create("ReverseCollectionEnabled", typeof(bool), typeof(ListView), false);

        public bool ReverseCollectionEnabled
        {
            get { return (bool)GetValue(ReverseCollectionEnabledProperty); }
            set { SetValue(ReverseCollectionEnabledProperty, value); }
        }

        public Type DataTemplateType
        {
            get { return (Type)GetValue(DataTemplateTypeProperty); }
            set { SetValue(DataTemplateTypeProperty, value); }
        }

        public string EmptyText
        {
            get { return (string)GetValue(EmptyTextProperty); }
            set { SetValue(EmptyTextProperty, value); }
        }


        public bool ScrollToTopChange
        {
            get { return (bool)GetValue(ScrollToTopChangeProperty); }
            set { SetValue(ScrollToTopChangeProperty, value); }
        }

        //public FontStyle EmptyTextFontStyle
        //{
        //    get { return (FontStyle)GetValue(EmptyTextFontStyleProperty); }
        //    set { SetValue(EmptyTextFontStyleProperty, value); }
        //}

        public double EmptyTextFontSize
        {
            get { return (double)GetValue(EmptyTextFontSizeProperty); }
            set { SetValue(EmptyTextFontSizeProperty, value); }
        }

        public Color EmptyTextColor
        {
            get { return (Color)GetValue(EmptyTextColorProperty); }
            set { SetValue(EmptyTextColorProperty, value); }
        }

        public FileImageSource EmptyTextBackground
        {
            get { return (FileImageSource)GetValue(EmptyTextBackgroundProperty); }
            set { SetValue(EmptyTextBackgroundProperty, value); }
        }

        public ListViewSelector Selector
        {
            get { return (ListViewSelector)GetValue(SelectorProperty); }
            set { SetValue(SelectorProperty, value); }
        }

        public bool Clickable
        {
            get { return (bool)GetValue(ClickableProperty); }
            set { SetValue(ClickableProperty, value); }
        }

        /// <summary>
        /// ios only
        /// </summary>
        public bool DismissKeyboardOnDrag
        {
            get { return (bool)GetValue(DismissKeyboardOnDragProperty); }
            set { SetValue(DismissKeyboardOnDragProperty, value); }
        }

        /// <summary>
        /// used for ios twintech only(note: dataSource override)
        /// </summary>
        public bool UseCustomRenderer
        {
            get { return (bool)GetValue(UseCustomRendererProperty); }
            set { SetValue(UseCustomRendererProperty, value); }
        }

        public bool SelectItemOnLongClick
        {
            get { return (bool)GetValue(SelectOnLongClickProperty); }
            set { SetValue(SelectOnLongClickProperty, value); }
        }

        public bool SwipeEnabled
        {
            get { return (bool)GetValue(SwipeEnabledProperty); }
            set { SetValue(SwipeEnabledProperty, value); }
        }

        /// <summary>
        /// android use only
        /// </summary>
        public int ScrollToIndex
        {
            get { return (int)GetValue(ScrollToIndexProperty); }
            set { SetValue(ScrollToIndexProperty, value); }
        }

        public int LoadMoreOffset
        {
            get { return (int)GetValue(LoadMoreOffsetProperty); }
            set { SetValue(LoadMoreOffsetProperty, value); }
        }

        public int LastVisiblePosition
        {
            get { return (int)GetValue(LastVisiblePositionProperty); }
            set { SetValue(LastVisiblePositionProperty, value); }
        }

        public FileImageSource SeparatorBackground
        {
            get { return (FileImageSource)GetValue(SeparatorBackgroundProperty); }
            set { SetValue(SeparatorBackgroundProperty, value); }
        }

        //public Color SeparatorColor
        //{
        //    get { return (Color)GetValue(SeparatorColorProperty); }
        //    set { SetValue(SeparatorColorProperty, value); }
        //}

        /// <summary>
        /// for android only
        /// </summary>
        public double SeparatorHeight
        {
            get { return (double)GetValue(SeparatorHeightProperty); }
            set { SetValue(SeparatorHeightProperty, value); }
        }

        /// <summary>
        /// for android only
        /// </summary>
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public FileImageSource TransparentSeparator
        {
            get { return (FileImageSource)GetValue(TransparentSeparatorProperty); }
            set { SetValue(TransparentSeparatorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ListView.ItemContainerStyle from a resource with a matching key for winRT.
        /// </summary>
        public string ItemContainerStyle
        {
            get { return (string)GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        public string Tag
        {
            get { return (string)GetValue(TagProperty); }
            set { SetValue(TagProperty, value); }
        }

        public event EventHandler LongClick;
        public event EventHandler<int> ScrollToBottomEvent = delegate { };
        public event EventHandler ScrollToTopEvent = delegate { };

        public void OnLongClick()
        {
            EventHandler handler = LongClick;
            if (handler != null)
                LongClick(this, null);
        }

        public void OnScrolledTop()
        {
            if (ReverseCollectionEnabled)
            {
                if (ItemsSource is ISupportReverseIncrementalLoading)
                {
                    var loaderSource = (ISupportReverseIncrementalLoading)ItemsSource;
                    if (!loaderSource.IsTopLoading && loaderSource.Count >= LoadMoreOffset)
                    {
                        loaderSource.LoadMoreTopItemsAsync(0);
                    }
                }
            }
        }

        public void ScrollToTop()
        {
            var loaderSource = ItemsSource;
            if (ItemsSource == null)
                return;

            var prop = ItemsSource.GetType().GetRuntimeProperty("Count");

            if (prop != null && prop.GetValue(ItemsSource) != null)
            {
                var count = int.Parse(prop.GetValue(ItemsSource).ToString());

                if (count > 0)
                {
                    //                    if (Device.RuntimePlatform == Device.iOS)
                    //                        await Task.Delay(1000);

                    //ScrollToTopEvent(null, null);


                    ScrollToTopChange = true;
                    //var source = (IList)ItemsSource;
                    //await Task.Delay(500);
                    //ScrollTo(source[0], ScrollToPosition.Start, false);
                }
            }

        }

        public void ScrollToBottom()
        {
            var loaderSource = ItemsSource;
            if (ItemsSource == null)
                return;

            var prop = ItemsSource.GetType().GetRuntimeProperty("Count");

            if (prop != null && prop.GetValue(ItemsSource) != null)
            {
                var count = int.Parse(prop.GetValue(ItemsSource).ToString());

                if (count > 0)
                {
                    var index = 0;
                    if (!this.IsGroupingEnabled)
                    {
                        index = count - 1;
                    }
                    else
                    {
                        var source = (IList)ItemsSource;
                        var cnt0 = count - 1;
                        var item = source[cnt0] as IList;
                        index = item.Count - 1;
                    }

                    //                    if (Device.RuntimePlatform == Device.iOS)
                    //                        await Task.Delay(1000);

                    if (index > 0)
                        ScrollToBottomEvent(this, index);

                }
            }

        }

        public ListView()
        //: base(ListViewCachingStrategy.RecycleElement)
        {
            //if (Xamarin.Forms.Device.OS != TargetPlatform.Android)
            this.ItemAppearing += ListView_ItemAppearing;
        }

        void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            HandleItemAppearing(e);
        }

        protected virtual void HandleItemAppearing(ItemVisibilityEventArgs e)
        {
            if (IsGroupingEnabled)
            {
                if (ItemsSource is ISupportIncrementalLoading)
                {
                    var loaderSource = (ISupportIncrementalLoading)ItemsSource;

                    var enumSource = (System.Collections.IList)ItemsSource;
                    if (!loaderSource.IsLoading)
                    {
                        if (loaderSource.Count > 0)
                        {
                            try
                            {
                                var lastIndex = loaderSource.Count - 1;
                                if (lastIndex < 0)
                                    return;

                                var listLastGroup = (System.Collections.IList)enumSource[lastIndex];

                                //var index = listLastGroup.Count - LoadMoreOffset;
                                //if (index < 0){
                                //	return;
                                //}

                                if (e.Item == listLastGroup)
                                    loaderSource.LoadMoreItemsAsync(0);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }
            else
            {
                if (ItemsSource is ISupportIncrementalLoading)
                {
                    var loaderSource = (ISupportIncrementalLoading)ItemsSource;

                    if (!loaderSource.IsLoading && loaderSource.Count >= LoadMoreOffset && LoadMoreOffset >= 0 && (loaderSource.Count - LoadMoreOffset - 1 > 0))
                    {
                        if (e.Item == loaderSource[loaderSource.Count - LoadMoreOffset - 1])
                        {
                            loaderSource.LoadMoreItemsAsync(0);
                        }
                    }
                }
            }
        }

        public void LoadMore()
        {
            if (IsGroupingEnabled)
            {
                if (ItemsSource is ISupportIncrementalLoading)
                {
                    var loaderSource = (ISupportIncrementalLoading)ItemsSource;
                    var enumSource = (System.Collections.IList)ItemsSource;
                    if (!loaderSource.IsLoading)
                    {
                        if (loaderSource.Count > 0 && LoadMoreOffset >= 0)
                        {
                            loaderSource.LoadMoreItemsAsync(0);
                        }
                    }
                }
            }
            else
            {
                if (ItemsSource is ISupportIncrementalLoading)
                {
                    var loaderSource = (ISupportIncrementalLoading)ItemsSource;

                    if (!loaderSource.IsLoading && loaderSource.Count > 0 && LoadMoreOffset >= 0)
                    {
                        loaderSource.LoadMoreItemsAsync(0);
                    }
                }
            }
        }
    }
}
