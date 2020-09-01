using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace MvvmAspire.Controls
{
    /*
     * a view which can be used as a cell in order to get optimum performance 
     */
    public abstract class FastCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
          BindableProperty.Create("SelectedBackgroundColor",
                                  typeof(Color),
                                  typeof(FastCell),
                                  Color.Default);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectionModeProperty =  BindableProperty.Create("SelectionMode",typeof(bool),typeof(FastCell),true);

        public bool SelectionMode
        {
            get { return (bool)GetValue(SelectionModeProperty); }
            set { SetValue(SelectionModeProperty, value); }
        }


        public bool IsInitialized
        {
            get;
            private set;
        }

        //		public Layout<Xamarin.Forms.View> Content { get; set; }

        /// <summary>
        /// Initializes the cell.
        /// </summary>
        public void PrepareCell()
        {
            InitializeCell();
            if (BindingContext != null)
            {
                SetupCell(false);
            }
            IsInitialized = true;
        }

        public void PrepareCell(Size cellSize)
        {
            InitializeCell();
            if (BindingContext != null)
            {
                SetupCell(false);
            }
            IsInitialized = true;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (IsInitialized)
            {
                SetupCell(true);
            }
        }

        /// <summary>
        /// Setups the cell. You should call InitializeComponent in here
        /// </summary>
        protected abstract void InitializeCell();

        /// <summary>
        /// Do your cell setup using the binding context in here.
        /// </summary>
        /// <param name="isRecycled">If set to <c>true</c> is recycled.</param>
        protected abstract void SetupCell(bool isRecycled);

        public object OriginalBindingContext;

    }
}

